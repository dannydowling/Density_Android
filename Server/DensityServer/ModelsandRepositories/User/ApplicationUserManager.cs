using DensityServer.Data;
using DensityServer.ModelsandRepositories.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DensityServer.ModelsandRepositories.User
{
    public class ApplicationUserManager : UserManager<UserModel>
    {
        private readonly IConfiguration _config;
        private IUserStore<UserModel> _store;
        DbContextOptions<UserModelsDbContext> _dbContextOptions;

        public ApplicationUserManager(
            DbContextOptions<UserModelsDbContext> dbContextOptions, 
            IUserStore<UserModel> store, 
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<UserModel> passwordHasher, 
            IEnumerable<IUserValidator<UserModel>> userValidators, 
            IEnumerable<IPasswordValidator<UserModel>> passwordValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            IServiceProvider services, 
            ILogger<UserManager<UserModel>> logger,
            IConfiguration config) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _store = store;
            _dbContextOptions = dbContextOptions;
            _config = config;
        }

        public override async Task<UserModel> FindByEmailAsync (string email)
        {
            using (var dbContext = new UserModelsDbContext(_config, _dbContextOptions))
            {
                return await dbContext.Set<UserModel>().FirstOrDefaultAsync(x => x.Email == email);
            }
        }

        public override async Task<UserModel> FindByIdAsync (string userId)
        {
            using (var dbContext = new UserModelsDbContext(_config, _dbContextOptions))
            {
                Guid id = Guid.Parse(userId);
                return await dbContext.Set<UserModel>().FirstOrDefaultAsync(x => x.Id == id);
            }            
        }

        public override async Task<IdentityResult> UpdateAsync (UserModel user)
        {
            using (var dbContext = new UserModelsDbContext(_config, _dbContextOptions))
            {
                var current = await dbContext.Set<UserModel>().FirstOrDefaultAsync(x => x.Id == user.Id);
                current.AccessFailedCount = user.AccessFailedCount;
                current.ConcurrencyStamp = user.ConcurrencyStamp;
                current.Email = user.Email;
                current.EmailConfirmationDate = user.EmailConfirmationDate;
                current.EmailConfirmed = user.EmailConfirmed;
                current.FirstName = user.FirstName;
                current.LastName = user.LastName;
                current.LockoutEnabled = user.LockoutEnabled;
                current.NormalizedEmail = user.NormalizedEmail;
                current.NormalizedUserName = user.NormalizedUserName;
                current.PhoneNumber = user.PhoneNumber;
                current.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
                current.Score = user.Score;
                current.SecurityStamp = user.SecurityStamp;
                current.TwoFactorEnabled = user.TwoFactorEnabled;
                current.UserName = user.UserName;

                await dbContext.SaveChangesAsync();
                return IdentityResult.Success;

            }
        }

        public override async Task<IdentityResult> ConfirmEmailAsync (UserModel user, string token)
        {
            var isValid = await base.VerifyUserTokenAsync(user, Options.Tokens.EmailConfirmationTokenProvider, ConfirmEmailTokenPurpose, token);

            if (isValid)
            {
                using (var dbContext = new UserModelsDbContext(_config, _dbContextOptions))
                {
                    var current = await dbContext.userModels.FindAsync(user.Id);
                    current.EmailConfirmationDate = DateTime.Now;
                    current.EmailConfirmed = true;

                    await dbContext.SaveChangesAsync();

                    return IdentityResult.Success;
                }                
            }
            return IdentityResult.Failed();
        }
    }
}
