using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisService.Utilities.ResponseDTO.LocationDTO
{
    public class Locations
    {
        public class Entity
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
        }
    }
}
