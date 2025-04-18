using Microsoft.EntityFrameworkCore;
using RedisService;
using RedisService.DataAccess.Data;
using StackExchange.Redis;
using WorkerService.DataAccess.Repository.IRepository;
using WorkerService.DataAccess.Repository;


var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseOracle(connectionString)
                   .EnableSensitiveDataLogging()
                   .LogTo(Console.WriteLine, LogLevel.Information));

        var redisConnectionStrings = configuration.GetSection("Redis:Configuration").Get<string>();

        var redisConnectionString = string.Join(",", redisConnectionStrings);
        services.AddSingleton<IConnectionMultiplexer>(sp =>
            ConnectionMultiplexer.Connect(redisConnectionString));
        services.AddHostedService<RedisBackgroundService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();



    });

var host = builder.Build();
await host.RunAsync();
