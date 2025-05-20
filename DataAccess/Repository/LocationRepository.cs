

using MasterAPI.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using RedisService.DataAccess.Data;
using RedisService.Models;
using RedisService.Utilities.ResponseDTO.LocationDTO;

namespace MasterAPI.DataAccess.Repository
{
    public class LocationRepository :  ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<List<Locations.Entity>> Depots()
        {
           var locations=await _context.Locations.Where(x => x.Status == "ACTV").Select(x => new Locations.Entity { Id = x.LocationId, Code = x.Code, Name = x.Name }).ToListAsync();
            return locations;
        }
       

    }
}
