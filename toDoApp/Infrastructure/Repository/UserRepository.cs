using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository: IUserRepository
    {
        private static List<User> _users = new List<User>();
        public UserRepository() { }
        public async Task<User> GetUserByEmail(string email)
        {
            return await Task.FromResult(_users.FirstOrDefault(x => x.Email == email));

        }
        public async Task<User> CreateUser(User user)
        {
            user.IdUser=Guid.NewGuid();
            _users.Add(user);
            return await Task.FromResult(user);
        }

    }
}
