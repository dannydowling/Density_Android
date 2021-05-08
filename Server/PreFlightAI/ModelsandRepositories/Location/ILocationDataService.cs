using System.Collections.Generic;
using System.Threading.Tasks;
using PreFlightAI.Shared;

namespace PreFlightAI.Server.Services
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
