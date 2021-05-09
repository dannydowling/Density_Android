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

        public DbSet<typedUser> typedUsers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Country> countries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, Name = "Belgium" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, Name = "Germany" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, Name = "Netherlands" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 4, Name = "USA" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 5, Name = "Japan" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 6, Name = "China" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 7, Name = "UK" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 8, Name = "France" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 9, Name = "Brazil" });

            //foreach... in positions... add the thing to the collection here...

            var locationsArray = JArray.Parse(DensityServer.Properties.Resources.Positions);
            var states = locationsArray
                .Select(x => x["state"]             //select every state
                .ToString())                        //as a string
                .Distinct()                         //one of each
                .OrderBy(x => x);                   //and set them in order

            var Locations = states.Select(s => new                          //select a new string from the collection of states                               
            {
                StateName = s,                                          //set the state name to be the entry in the states collection
                Cities = locationsArray
                .Where(x => x["state"]                                  //the cities are where the state name matches
                .ToString() == s                                        //as a string to the state
                         && !string.IsNullOrWhiteSpace(x["icao"]        //and there is a valid icao code
                         .ToString()))                                  //as a string
                                .Select(x =>
                                modelBuilder.Entity<Location>().HasData(
                                new Location                            //so we make a new location for the city
                                {
                                    city = x["city"].ToString(),        //the name of the city matches the city tag
                                    icao = x["icao"].ToString(),        //the icao code matches the icao tag
                                    name = x["name"].ToString(),        //the name of the airport matches the name tag
                                    lat = Convert.ToDouble(x["lat"]),   //the latitude matches the lat tag
                                    lon = Convert.ToDouble(x["lon"])    //the longitude matches the lon tag
                                }))
                                     .ToList()                          //set the locations into a list
            }).ToDictionary(s => s.StateName, s => s.Cities);           //into a dictionary of statename and a list of locations called cities
        }
    }
}

