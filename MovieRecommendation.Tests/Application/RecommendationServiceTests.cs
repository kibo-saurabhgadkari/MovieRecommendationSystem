using Moq;
using NUnit.Framework;
using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Handlers;
using MovieRecommendation.Application;
using System.Collections.Generic;

namespace MovieRecommendation.Tests
{
    public class RecommendationServiceTests
    {
        private Mock<IRecommendationHandler> _mockRecommendationHandler;
        private RecommendationService _recommendationService;

        [SetUp]
        public void Setup()
        {
            _mockRecommendationHandler = new Mock<IRecommendationHandler>();
            _recommendationService = new RecommendationService(_mockRecommendationHandler.Object);
        }

        [Test]
        public void GetRecommendations_ReturnsRecommendationsForUser()
        {
            // Arrange
            var userId = 1;
            var recommendations = new List<Recommendation> 
            { 
                new Recommendation(movie: new Movie("Movie1", new List<Genre> { new Genre { GenreId = 1, GenreName = "Genre1" } },
                    new List<Director> { new Director { DirectorId = 1, DirectorName = "Director1" } }), relevanceScore: 1.5), 
                new Recommendation(movie: new Movie("Movie2", new List<Genre> { new Genre { GenreId = 2, GenreName = "Genre2" } },
                    new List<Director> { new Director { DirectorId =21, DirectorName = "Director2" } }), relevanceScore: 1.5) };
            _mockRecommendationHandler.Setup(handler => handler.GetRecommendations(userId)).Returns(recommendations);

            // Act
            var result = _recommendationService.GetRecommendations(userId);

            // Assert
            Assert.AreEqual(recommendations, result);
        }
    }
}
