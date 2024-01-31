using MovieRecommendation.Domain.Entities;
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
            var userId = 1;
            var userName = "john_doe";

            // Act
            var user = new User(userId, userName);

            // Assert
            Assert.AreEqual(userId, user.UserId);
            Assert.AreEqual(userName, user.UserName);
        }
    }
}
