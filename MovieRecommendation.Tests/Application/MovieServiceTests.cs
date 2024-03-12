using Moq;
using NUnit.Framework;
using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Handlers;
using MovieRecommendation.Application;
using System.Collections.Generic;

namespace MovieRecommendation.Tests
{
    public class MovieServiceTests
    {
        private Mock<IMovieHandler> _mockMovieHandler;
        private MovieService _movieService;

        [SetUp]
        public void Setup()
        {
            _mockMovieHandler = new Mock<IMovieHandler>();
            _movieService = new MovieService(_mockMovieHandler.Object);
        }

        [Test]
        public void GetAllMovies_ReturnsAllMovies()
        {
            // Arrange
            var movies = new List<Movie>
            {
                new Movie("Movie1", new List<Genre> { new Genre { GenreId = 1, GenreName = "Genre1" } },
                    new List<Director> { new Director { DirectorId = 1, DirectorName = "Director1" } }),
                 new Movie("Movie2", new List<Genre> { new Genre { GenreId = 2, GenreName = "Genre2" } },
                    new List<Director> { new Director { DirectorId = 2, DirectorName = "Director2" } }),
            };

            _mockMovieHandler.Setup(handler => handler.GetAllMovies()).Returns(movies);

            // Act
            var result = _movieService.GetAllMovies();

            // Assert
            Assert.AreEqual(movies, result);
        }

        [Test]
        public void AddMovie_AddsMovieSuccessfully()
        {
            // Arrange
            var title = "Test Movie";
            var genres = new List<Genre> { new Genre() };
            var directors = new List<Director> { new Director() };

            _mockMovieHandler.Setup(handler => handler.AddMovie(title, genres, directors)).Verifiable();

            // Act
            _movieService.AddMovie(title, genres, directors);

            // Assert
            _mockMovieHandler.Verify(handler => handler.AddMovie(title, genres, directors), Times.Once);
        }
    }
}
