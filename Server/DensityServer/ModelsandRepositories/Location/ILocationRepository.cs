using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DensityServer.Shared;

namespace DensityServer.Api.Models
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAllLocations();
        Location GetLocationById(string icao);
        Location AddLocation(Location location);
    }
}
