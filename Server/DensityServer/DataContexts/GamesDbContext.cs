using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using DensityServer.Shared;
using System.Linq;
using DensityServer.ModelsandRepositories.User;
using Microsoft.Extensions.Configuration;
using DensityServer.ModelsandRepositories.Game;
using Microsoft.AspNetCore.Mvc;

namespace DensityServer.Data
{
    public class GamesDbContext : DbContext
    {
        private readonly IConfiguration _config;
      
        public GamesDbContext([FromServices]IConfiguration config, DbContextOptions<GamesDbContext> options)
            : base(options)
        {
            _config = config ?? throw new System.ArgumentNullException(nameof(config));
        }
        public DbSet<GameModel> gameModels { get; set; }

        
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["gameDbConnectionString"], options =>
            { options.MigrationsHistoryTable("__GameMigrationsHistory", "Games"); });
        }
    }
}


