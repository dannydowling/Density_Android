using System.Collections.Generic;
using System.Linq;
using DensityServer.Shared;
using DensityServer.Data;

namespace DensityServer.Api.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<typedUser> GetAllUsers()
        {
            return _appDbContext.typedUsers;
        }

        public typedUser GetUserById(int userId)
        {
            return _appDbContext.typedUsers.FirstOrDefault(c => c.userId == userId);
        }

        public typedUser AddUser(typedUser user)
        {
            var addedEntity = _appDbContext.typedUsers.Add(user);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public typedUser UpdateUser(typedUser user)
        {
            var foundUser = _appDbContext.typedUsers.FirstOrDefault(e => e.userId == user.userId);

            if (foundUser != null)
            {              
                foundUser.email =           user.email;
                foundUser.firstName =       user.firstName;
                foundUser.lastName =        user.lastName;   
                foundUser.Password =        user.Password;

                _appDbContext.SaveChanges();

                return foundUser;
            }

            return null;
        }

        public void DeleteUser(int userId)
        {
            var foundUser = _appDbContext.typedUsers.FirstOrDefault(e => e.userId == userId);
            if (foundUser == null) return;

            _appDbContext.typedUsers.Remove(foundUser);
            _appDbContext.SaveChanges();
        }
    }
}
