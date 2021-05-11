using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DensityServer.Data;
using DensityServer.Shared;

namespace DensityServer.Api.Models
{
    public class LocationRepository : ILocationRepository
    {
        private AppDbContext _appDbContext { get; set; }

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

        public Location AddLocation(Location location)
        {
            _appDbContext.locations.Add(location);
            return location;
        }

        public object DeleteLocation(string icao)
        {
         return _appDbContext.locations.Remove(GetLocationById(icao));            
        }

        public Location UpdateLocation(Location location)
        {
            _appDbContext.locations.Remove(GetLocationById(location.icao));
            _appDbContext.locations.Add(location);
            return location;
        }
    }
}
