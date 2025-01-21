using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthenticationService
    {
        private readonly IUserRepository _userInterface;
        private readonly ITokenService _jwtTokenGenerator;

        public AuthenticationService(IUserRepository userInterface, ITokenService jwtTokenGenerator)
        {
            _userInterface = userInterface;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<User> RegisterNewUser(string email, string password, string name)
        {
            var token = _jwtTokenGenerator.GenerateToken(name, email);


            var ExistingUser = await _userInterface.GetUserByEmail(email);
            if (ExistingUser == null)
            {
                var newUser = new User
                {
                    Email = email,
                    Password = password,
                    Username = name,
                    Token = token
                };
                return await _userInterface.CreateUser(newUser);
            }
            else
                return null;

        }

    }
}
