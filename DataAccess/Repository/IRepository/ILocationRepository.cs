

using RedisService.Utilities.ResponseDTO.LocationDTO;

namespace MasterAPI.DataAccess.Repository.IRepository
{
    public interface ILocationRepository 
    {
        Task<List<Locations.Entity>> Depots();

    }
}
