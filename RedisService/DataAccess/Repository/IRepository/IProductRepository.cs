
using RedisService.Utilities.ResponseDTO.GetProductDetails;
using static RedisService.Utilities.ResponseDTO.GetProductDetails.GetProductDetails;

namespace RedisService.DataAccess.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<List<GetProductDetails.ProductDetails>> GetAllProductDetails();
        Task<List<GetProductDetails.ProductBatch>> GetProductBatches();
    }
}
