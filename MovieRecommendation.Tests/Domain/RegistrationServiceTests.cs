using Moq;
using NUnit.Framework;
using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Repository;
using MovieRecommendation.Domain.Services;

namespace MovieRecommendation.Tests
{
    public class RegistrationServiceTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private AuthenticationService _authenticationService;
        private RegistrationService _registrationService;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _authenticationService = new AuthenticationService(_mockUserRepository.Object);
            _registrationService = new RegistrationService(_mockUserRepository.Object, _authenticationService);
        }

        [Test]
        public void RegisterUser_ValidUserNameAndPassword_ReturnsRegisteredResult()
        {
            // Arrange
            var userName = "john_doe";
            var password = "password";
            var hashedPassword = _authenticationService.HashPassword(password);

            _mockUserRepository.Setup(repo => repo.IsUsernameTaken(userName)).Returns(false);
            _mockUserRepository.Setup(repo => repo.AddUser(It.IsAny<User>())).Returns(1);

            // Act
            var result = _registrationService.RegisterUser(userName, password);

            // Assert
            Assert.IsTrue(result.IsAuthenticated);
            Assert.AreEqual(userName, result.Username);
            Assert.AreEqual("Registered successfully", result.Message);
        }

        [Test]
        public void RegisterUser_UserNameAlreadyTaken_ReturnsNotRegisteredResult()
        {
            // Arrange
            var userName = "john_doe";
            var password = "password";

            _mockUserRepository.Setup(repo => repo.IsUsernameTaken(userName)).Returns(true);

            // Act
            var result = _registrationService.RegisterUser(userName, password);

            // Assert
            Assert.IsFalse(result.IsAuthenticated);
            Assert.AreEqual("Username already taken", result.Message);
        }

        [Test]
        public void RegisterUser_EmptyUserNameOrPassword_ReturnsNotRegisteredResult()
        {
            // Arrange
            var userName = "";
            var password = "";

            // Act
            var result = _registrationService.RegisterUser(userName, password);

            // Assert
            Assert.IsFalse(result.IsAuthenticated);
            Assert.AreEqual("Username or password invalid", result.Message);
        }
    }
}
