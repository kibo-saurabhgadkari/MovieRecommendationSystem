using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Repository;
using System.Security.Cryptography;
using System.Text;

namespace MovieRecommendation.Domain.Services
{
    public class AuthenticationService
    {
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public AuthenticationResult Authenticate(string userName, string enteredPassword)
        {
            AuthenticationResult result = new AuthenticationResult();

            var user = _userRepository.GetUserByUserName(userName);

            if (user == null)
            {
                result.IsAuthenticated = false;
                result.Message = "User does not exist";
                return result;
            }

            var storedHash = user.Password;

            if (HashPassword(enteredPassword) == storedHash)
            {
                result.IsAuthenticated = true;
                result.UserId = user.UserId;
                result.Username = user.UserName;
                result.Message = "Authenticated successfully";
            }

            return result;
        }
    }
}
