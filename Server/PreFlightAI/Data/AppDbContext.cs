using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PreFlightAI.Shared;

namespace PreFlightAI.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
           
        }
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<typedUser> typedUsers { get; set; }
       
        public DbSet<Location> Locations { get; set; }


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

            modelBuilder.Entity<Location>().HasData(new Location { LocationId = 1, Name = "Juneau" });
            modelBuilder.Entity<Location>().HasData(new Location { LocationId = 2, Name = "Sitka" });
            modelBuilder.Entity<Location>().HasData(new Location { LocationId = 3, Name = "Ketchikan" });
            modelBuilder.Entity<Location>().HasData(new Location { LocationId = 4, Name = "Petersburg" });
            modelBuilder.Entity<Location>().HasData(new Location { LocationId = 5, Name = "Wrangell" });



        }
    }
}
