using Moq;
using NUnit.Framework;
using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Repository;
using MovieRecommendation.Domain.Services;

namespace MovieRecommendation.Tests
{
    public class AuthenticationServiceTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private AuthenticationService _authenticationService;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _authenticationService = new AuthenticationService(_mockUserRepository.Object);
        }

        [Test]
        public void Authenticate_UserExistsAndPasswordMatches_ReturnsAuthenticatedResult()
        {
            // Arrange
            var userName = "john_doe";
            var password = "password";
            var hashedPassword = _authenticationService.HashPassword(password);
            var user = new User(userName, hashedPassword);

            _mockUserRepository.Setup(repo => repo.GetUserByUserName(userName)).Returns(user);

            // Act
            var result = _authenticationService.Authenticate(userName, password);

            // Assert
            Assert.IsTrue(result.IsAuthenticated);
            Assert.AreEqual(userName, result.Username);
            Assert.AreEqual("Authenticated successfully", result.Message);
        }

        [Test]
        public void Authenticate_UserExistsAndPasswordDoesNotMatch_ReturnsNotAuthenticatedResult()
        {
            // Arrange
            var userName = "john_doe";
            var password = "password";
            var wrongPassword = "wrong_password";
            var hashedPassword = _authenticationService.HashPassword(password);
            var user = new User(userName, hashedPassword);

            _mockUserRepository.Setup(repo => repo.GetUserByUserName(userName)).Returns(user);

            // Act
            var result = _authenticationService.Authenticate(userName, wrongPassword);

            // Assert
            Assert.IsFalse(result.IsAuthenticated);
        }

        [Test]
        public void Authenticate_UserDoesNotExist_ReturnsNotAuthenticatedResult()
        {
            // Arrange
            var userName = "john_doe";
            var password = "password";

            _mockUserRepository.Setup(repo => repo.GetUserByUserName(userName)).Returns((User)null);

            // Act
            var result = _authenticationService.Authenticate(userName, password);

            // Assert
            Assert.IsFalse(result.IsAuthenticated);
        }
    }
}
