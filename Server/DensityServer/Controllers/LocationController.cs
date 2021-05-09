using DensityServer.Api.Models;
using DensityServer.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DensityServer.Api.Controllers
{
    [Route("location/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        // Post: location/aaaa
        [HttpPost("{id}")]
        public IActionResult AddLocation(Location location)
        {
            return Ok(_locationRepository.AddLocation(location));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(string icao)
        {
            return Ok(_locationRepository.DeleteLocation(icao));
        }

        // GET location/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetLocationById(string icao)
        {
            return Ok(_locationRepository.GetLocationById(icao));
        }

        // GET: location/<controller>
        [HttpGet]
        public IActionResult GetAllLocations()
        {
            return Ok(_locationRepository.GetAllLocations());
        }


        // Put: location/aaaa
        [HttpPatch("{Id}")]
        public IActionResult UpdateLocation(Location location)
        {
            return Ok(_locationRepository.UpdateLocation(location));
        }
    }
}
