using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using DensityServer.Shared;
using System.Linq;
using DensityServer.ModelsandRepositories.User;

namespace DensityServer.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options)
            : base(options)
        { 
        }
            public DbSet<UserModel> userModels { get; set; }
    }
} 