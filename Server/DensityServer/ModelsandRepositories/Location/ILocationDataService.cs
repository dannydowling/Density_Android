using System.Collections.Generic;
using System.Threading.Tasks;
using DensityServer.Shared;

namespace DensityServer.Server.Services
{
    public interface ILocationDataService
    {
        Task<IEnumerable<Location>> GetAllLocations();
        Task<Location> GetLocationById(string icao);
        Task<Location> AddLocation(Location location);
        Task UpdateLocation(Location location);
        Task DeleteLocation(string icao);
    }
}
