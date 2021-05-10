﻿using DensityServer.Api.Models;
using DensityServer.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DensityServer.Api.Controllers
{
    [Route("Airport/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [Authorize]
        // Post: Airport/airport
        [HttpPost("{id}")]
        public IActionResult AddLocation(Location location)
        {
            return Ok(_locationRepository.AddLocation(location));
        }

        [Authorize]
        //Delete: Airport/Delete/aaaa
        [HttpDelete("/Delete/{id}")]
        public IActionResult DeleteLocation(string icao)
        {
            return Ok(_locationRepository.DeleteLocation(icao));
        }

        // GET Airport/aaaa
        [HttpGet("{id}")]
        public IActionResult GetLocationById(string icao)
        {
            return Ok(_locationRepository.GetLocationById(icao));
        }

        // GET: Airport
        [HttpGet]
        public IActionResult GetAllLocations()
        {
            return Ok(_locationRepository.GetAllLocations());
        }

        [Authorize]
        // Patch: Airport/Edit/aaaa
        [HttpPatch("/Edit/{Id}")]
        public IActionResult UpdateLocation(Location location)
        {
            return Ok(_locationRepository.UpdateLocation(location));
        }
    }
}
