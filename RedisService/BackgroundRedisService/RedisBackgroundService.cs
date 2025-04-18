
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RedisService.Utilities.ResponseDTO.GetProductDetails;
using StackExchange.Redis;
using WorkerService.DataAccess.Repository.IRepository;

namespace RedisService
{
    public class RedisBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<RedisBackgroundService> _logger;
        private readonly TimeSpan _interval = TimeSpan.FromDays(1); 
        private readonly IConnectionMultiplexer _redis;
        public RedisBackgroundService(IServiceScopeFactory scopeFactory, IConnectionMultiplexer redis, ILogger<RedisBackgroundService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
            _redis = redis;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(" Redis Background Service has started executing.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Fetching product details and storing in Redis.");
                    await StoreProductDetailsInRedisCache();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, " Error occurred while updating Redis cache.");
                }

                await Task.Delay(_interval, stoppingToken);
            }

            _logger.LogInformation("Redis Background Service is stopping.");
        }
        private async Task StoreProductDetailsInRedisCache()
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                // Run queries asynchronously
                List<GetProductDetails.ProductDetails> products =  await _unitOfWork.Product.GetAllProductDetails();

                List<GetProductDetails.ProductBatch> productBatches = await _unitOfWork.Product.GetProductBatches();
            

                var db = _redis.GetDatabase();

                // Store products in Redis Hash
                foreach (var product in products)
                {
                    string productJson = JsonSerializer.Serialize(product);
                    await db.HashSetAsync("Products", product.ProductId.ToString(), productJson);
                }

                // Store product batches in Redis Hash
                foreach (var batch in productBatches)
                {
                    string batchJson = JsonSerializer.Serialize(batch);
                    await db.HashSetAsync("ProductBatches", batch.BatchId.ToString(), batchJson);
                }
                await db.KeyExpireAsync("Products", TimeSpan.FromDays(1)); 
                await db.KeyExpireAsync("ProductBatches", TimeSpan.FromDays(1));
               _logger.LogInformation("Product details stored successfully in Redis.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while storing product details in Redis.");
            }
    }
    }
}
