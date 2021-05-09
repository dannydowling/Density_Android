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

        // GET: location/<controller>
        [HttpGet]
        public IActionResult GetLocations()
        {
            return Ok(_locationRepository.GetAllLocations());
        }

        // GET location/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetLocationById(string icao)
        {
            return Ok(_locationRepository.GetLocationById(icao));
        }

        [HttpPost("{id}")]
        public IActionResult AddLocation(Location location) 
        {
            return Ok(_locationRepository.AddLocation(location));
        }
    }
}
