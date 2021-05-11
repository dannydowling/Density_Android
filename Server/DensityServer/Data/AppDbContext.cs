using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using DensityServer.Shared;
using System.Linq;

namespace DensityServer.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Location> locations { get; set; }
       

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

