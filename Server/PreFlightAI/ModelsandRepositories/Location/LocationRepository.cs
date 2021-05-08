using System.Collections.Generic;
using System.Linq;
using DensityServer.Data;
using DensityServer.Shared;

namespace DensityServer.Api.Models
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _appDbContext;

        public LocationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _appDbContext.locations;
        }

        public Location GetLocationById(string icao)
        {
            return _appDbContext.locations.FirstOrDefault(c => c.icao == icao);
        }
    }
}
