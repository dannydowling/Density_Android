using DensityServer.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DensityServer.Data
{
    //https://www.codeproject.com/Articles/1237253/Entity-Framework-Core-with-multiple-DB-Contexts-Sc

    public class AirportsDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public AirportsDbContext([FromServices]IConfiguration config, DbContextOptions<AirportsDbContext> options)
            : base(options)
        {
            _config = config ?? throw new System.ArgumentNullException(nameof(config));
        }

        public DbSet<Location> locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder airportOptions)
        {
            airportOptions.UseSqlServer(_config["airportDbConnectionString"], options =>
            {
                //table name, schema
                options.MigrationsHistoryTable("__AirportMigrationsHistory", "Airports");
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //foreach... in positions... add the thing to the collection here...

            var locationsArray = JArray.Parse(DensityServer.Properties.Resources.Positions);
            var countries = locationsArray
                .Select(x => x["country"]
                .ToString())
                .Distinct()
                .OrderBy(x => x);

            var Locations = countries.Select(c => new
            {
                CountryName = c,
                Locations = locationsArray
                .Where(x => x["country"]        //find by country name
                .ToString() == c
                && !string.IsNullOrWhiteSpace(x["city"]     //if the entry contains a city
                .ToString()))
                            .Where(s => s["state"]          // if the state is in the country
                            .ToString() == c).Select(x =>
                                modelBuilder.Entity<Location>().HasData(        //build it out as a location
                                new Location
                                {
                                    country = x["country"].ToString(),
                                    state = x["state"].ToString(),
                                    city = x["city"].ToString(),
                                    icao = x["icao"].ToString(),
                                    name = x["name"].ToString(),
                                    lat = (x["lat"]).ToString(),
                                    lon = (x["lon"]).ToString()
                                }))
                                     .ToList()
            }).ToDictionary(s => s.CountryName, s => s.Locations);
        }
    }
}

