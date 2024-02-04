using Moq;
using NUnit.Framework;
using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Repository;
using MovieRecommendation.Domain.Handlers;
using System.Collections.Generic;
using System.Linq;

namespace MovieRecommendation.Tests
{
    public class RecommendationHandlerTests
    {
        private Mock<IMovieRepository> _mockMovieRepository;
        private Mock<IUserRepository> _mockUserRepository;
        private RecommendationHandler _recommendationHandler;

        [SetUp]
        public void Setup()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _recommendationHandler = new RecommendationHandler(_mockMovieRepository.Object, _mockUserRepository.Object);
        }

        [Test]
        public void GetRecommendations_ValidUserId_ReturnsRecommendations()
        {
            // Arrange
            var userId = 1;
            var user = new User("john_doe", "password")
            {
                UserId = userId
            };
            var movies = new List<Movie>
            {
                new Movie("Movie1", new List<Genre> { new Genre { GenreId = 1, GenreName = "Genre1" } },
                    new List<Director> { new Director { DirectorId = 1, DirectorName = "Director1" } }),
                 new Movie("Movie2", new List<Genre> { new Genre { GenreId = 2, GenreName = "Genre2" } },
                    new List<Director> { new Director { DirectorId = 2, DirectorName = "Director2" } }),
            };
            var preferences = new UserPreferences
            {
                PreferredGenres = new List<Genre> { new Genre { GenreId = 1, GenreName = "Genre1" } },
                PreferredDirectors = new List<Director> { new Director { DirectorId = 1, DirectorName = "Director1" } }
            };

            user.Preferences = preferences;

            _mockUserRepository.Setup(repo => repo.GetUserById(userId)).Returns(user);
            _mockMovieRepository.Setup(repo => repo.GetAllMovies()).Returns(movies);

            // Act
            var recommendations = _recommendationHandler.GetRecommendations(userId);

            // Assert
            Assert.AreEqual(2, recommendations.Count);
            Assert.AreEqual(1.5, recommendations.First().RelevanceScore);
        }

        [Test]
        public void GetRecommendations_InvalidUserId_ReturnsEmptyList()
        {
            // Arrange
            var userId = 1;

            _mockUserRepository.Setup(repo => repo.GetUserById(userId)).Returns((User)null);

            // Act
            var recommendations = _recommendationHandler.GetRecommendations(userId);

            // Assert
            Assert.AreEqual(0, recommendations.Count);
        }
    }
}
