using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.Domain.Services
{
    public class RegistrationService
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthenticationService _authenticationService;
        public RegistrationService(IUserRepository userRepository, AuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        public AuthenticationResult RegisterUser(string userName, string Password)
        {
            AuthenticationResult result;

            // Basic validation
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(Password))
            {
                // Validation failed
                result = new AuthenticationResult()
                {
                    IsAuthenticated = false,
                    Message = "Username or password invalid"
                };

                return result;
            }

            // Check if the username is already taken
            if (_userRepository.IsUsernameTaken(userName))
            {
                // Username is already taken
                result = new AuthenticationResult
                {
                    IsAuthenticated = false,
                    Message = "Username already taken"
                };

                return result;
            }

            // Hash the password before storing it in the database
            string hashedPassword = _authenticationService.HashPassword(Password);

            // Create a new user entity
            var newUser = new User(userName, hashedPassword);

            // Add the user to the repository
            var userId = _userRepository.AddUser(newUser);

            // Registration successful
            result = new AuthenticationResult
            {
                UserId = userId,
                Username = userName,
                IsAuthenticated = true,
                Message = "Registered successfully"
            };

            return result;
        }
    }
}
