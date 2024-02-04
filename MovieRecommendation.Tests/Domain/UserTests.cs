using Moq;
using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Repository;
using MovieRecommendation.Domain.Services;
using NUnit.Framework;

namespace MovieRecommendation.Tests.Domain
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void User_Can_Be_Created()
        {
            // Arrange
            var userName = "john_doe";
            var password = "password";

            // Act
            var user = new User(userName, password);

            // Assert
            Assert.AreEqual(userName, user.UserName);
            Assert.AreEqual(password, user.Password);
        }     

    }
}
