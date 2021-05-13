using DensityServer.ModelsandRepositories.Employee;
using DensityServer.ModelsandRepositories.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DensityServer.Services
{
    public class UserService : IUserService
    {
        private ILogger<UserService> _logger;
        private ApplicationUserManager _userManager;
        public UserService(ApplicationUserManager applicationUserManager, ILogger<UserService> logger)
        {
            _userManager = applicationUserManager;
            _logger = logger;

            var emailTokenProvider = new EmailTokenProvider<UserModel>();
            _userManager.RegisterTokenProvider("Default", emailTokenProvider);
        }


        public async Task<bool> ConfirmEmail(string email, string code)
        {
            var start = DateTime.Now;
            _logger.LogTrace($"Confirm Email email for user {email}");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    return false;
                }

                var result = await _userManager.ConfirmEmailAsync(user, code);
                return result.Succeeded;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Cannot confirm email for user {email} - {ex}");
                return false;
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogTrace($"Confirm email for user finished in {stopwatch.Elapsed}");
            }
        }

        public async Task<bool> RegisterUser(UserModel userModel)
        {
            var start = DateTime.Now;
            _logger.LogTrace($"Start register user {userModel.Email} - {start}");
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                userModel.UserName = userModel.Email;
                var result = await _userManager.CreateAsync(userModel, userModel.Password);
                return result == IdentityResult.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Cannot register user {userModel.Email} - {ex}");
                return false;
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogTrace($"Start register user {userModel.Email} finished at {DateTime.Now} - elapsed {stopwatch.Elapsed.TotalSeconds} second(s)");
            }
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> IsUserExisting(string email)
        {
            return (await _userManager.FindByEmailAsync(email)) != null;
        }

        //pass in a big number, get a list of all users.
        public async Task<IEnumerable<UserModel>> GetTopUsers(int numberOfUsers)
        {
            if (numberOfUsers >= 15)
            {
                numberOfUsers = 15;
            }

            var userList = await _userManager.Users.OrderByDescending(x => x.Score).ToListAsync();
            return userList.GetRange(0, numberOfUsers);
        }

        public async Task UpdateUser(UserModel userModel)
        {
            await _userManager.UpdateAsync(userModel);
        }

    }
}
