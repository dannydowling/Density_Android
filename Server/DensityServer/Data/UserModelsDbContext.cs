using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using DensityServer.Shared;
using System.Linq;
using DensityServer.ModelsandRepositories.User;

namespace DensityServer.Data
{
    public class UserModelsDbContext : IdentityDbContext
    {
        public UserModelsDbContext(DbContextOptions<UserModelsDbContext> options)
            : base(options)
        {

        }

        public DbSet<UserModel> userModels { get; set; }

        public DbSet<EmployeeModel> emplpoyeeModels { get; set; }
    }
}



