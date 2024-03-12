
using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Services;

namespace MovieRecommendation.Application
{
    public interface IUserService
    {
        AuthenticationResult LoginUser(string loginUsername, string loginPassword);
        AuthenticationResult RegisterUser(string username, string password);
    }

    public class UserService : IUserService
    {
        public readonly AuthenticationService _authenticationService;
        public readonly RegistrationService _registrationService;
        public UserService(AuthenticationService authenticationService, RegistrationService registrationService)
        {
            _authenticationService = authenticationService;
            _registrationService = registrationService;
        }

        public AuthenticationResult LoginUser(string loginUsername, string loginPassword)
        {
            return _authenticationService.Authenticate(loginUsername, loginPassword);
        }

        public AuthenticationResult RegisterUser(string username, string password)
        {
            //retrun _registrationService.RegisterUser(username, password);
            return _registrationService.RegisterUser(username, password);
        }
    }
}
