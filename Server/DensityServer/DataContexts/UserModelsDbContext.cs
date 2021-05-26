using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using DensityServer.Shared;
using System.Linq;
using DensityServer.ModelsandRepositories.User;
using Microsoft.Extensions.Configuration;

namespace DensityServer.Data
{
    public class UserModelsDbContext : DbContext
    {
        private readonly IConfiguration _config;
        public UserModelsDbContext(IConfiguration config, DbContextOptions<UserModelsDbContext> options)
            : base(options)
        {
            _config = config ?? throw new System.ArgumentNullException(nameof(config));
        }

        public DbSet<UserModel> userModels { get; set; }

        public DbSet<EmployeeModel> employeeModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["userDbConnectionString"], options =>
            {
                //table name, schema
                options.MigrationsHistoryTable("__UsersMigrationsHistory", "Users");
            });
        }
    }
}





