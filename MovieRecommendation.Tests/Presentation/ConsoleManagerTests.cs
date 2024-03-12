//using Moq;
//using NUnit.Framework;
//using MovieRecommendation.Application;
//using MovieRecommendation.Domain.Entities;
//using MovieRecommendation.Domain.Services;
//using MovieRecommendation.Domain.Repository;
//using MovieRecommendation.Domain.Handlers;
//using static ConsoleManager;

//namespace MovieRecommendation.Tests
//{
//    public class ConsoleManagerTests
//    {
//        private Mock<IUserRepository> _mockUserRepository;
//        private Mock<IUserService> _mockUserService;
//        private Mock<IMovieService> _mockMovieService;
//        private Mock<IRecommendationService> _mockRecommendationService;
//        private Mock<AuthenticationService> _mockAuthenticationService;
//        private Mock<RegistrationService> _mockRegistrationService;
//        private Mock<IMovieHandler> _mockMovieHandler;
//        private Mock<IRecommendationHandler> _mockRecommendationHandler;
//        private ConsoleManager _consoleManager;
//        private Mock<IConsoleWrapper> _mockConsoleWrapper;

//        [SetUp]
//        public void Setup()
//        {
//            //_mockUserRepository = new Mock<IUserRepository>();
//            //_mockAuthenticationService = new Mock<AuthenticationService>(_mockUserRepository.Object);
//            //_mockRegistrationService = new Mock<RegistrationService>(_mockUserRepository.Object, _mockAuthenticationService.Object);
//            //_mockMovieHandler = new Mock<IMovieHandler>();
//            //_mockMovieService = new Mock<IMovieService>(_mockMovieHandler.Object);
//            //_mockUserService = new Mock<IUserService>(_mockAuthenticationService.Object, _mockRegistrationService.Object);
//            ////_mockUserService = new Mock<UserService>();
//            //_mockRecommendationHandler = new Mock<IRecommendationHandler>();
//            //_mockRecommendationService = new Mock<IRecommendationService>(_mockRecommendationHandler.Object);
//            //_consoleManager = new ConsoleManager(_mockUserService.Object, _mockMovieService.Object, _mockRecommendationService.Object);

//            _mockUserService = new Mock<IUserService>();
//            _mockMovieService = new Mock<IMovieService>();
//            _mockRecommendationService = new Mock<IRecommendationService>();
//            _mockConsoleWrapper = new Mock<IConsoleWrapper>();
//            _consoleManager = new ConsoleManager(_mockUserService.Object, _mockMovieService.Object, _mockRecommendationService.Object, _mockConsoleWrapper.Object);
//        }

//        [Test]
//        public void Register_UserDoesNotExist_CreatesNewUser()
//        {
//            // Arrange
//            var username = "test_user";
//            var password = "test_password";
//            var authResult = new AuthenticationResult { IsAuthenticated = true, UserId = 1, Username = username };

//            _mockUserService.Setup(service => service.RegisterUser(username, password)).Returns(authResult);
            
//            //var mockConsole = new Mock<_consoleWrapper>();
//            _mockConsoleWrapper.Setup(c => c.ReadLine()).Returns("mockedUserInput");

//            // Inject the mockConsole into the class that uses _consoleWrapper.ReadLine()
//            // Then execute the test logic that involves reading from the console


//            // Act
//            var result = _consoleManager.Register();

//            // Assert
//            Assert.IsTrue(result.IsAuthenticated);
//            Assert.AreEqual(username, result.Username);
//        }

//        [Test]
//        public void Login_UserExistsAndCorrectPassword_ReturnsAuthenticatedUser()
//        {
//            // Arrange
//            var username = "test_user";
//            var password = "test_password";
//            var authResult = new AuthenticationResult { IsAuthenticated = true, UserId = 1, Username = username };

//            _mockUserService.Setup(service => service.LoginUser(username, password)).Returns(authResult);

//            // Act
//            var result = _consoleManager.Login();

//            // Assert
//            Assert.IsTrue(result.IsAuthenticated);
//            Assert.AreEqual(username, result.Username);
//        }

//        [Test]
//        public void ViewAvailableMovies_MoviesExist_ReturnsListOfMovies()
//        {
//            // Arrange
//            var movies = new List<Movie>
//                    {
//                        new Movie("Test Movie",
//                                  new List<Genre> { new Genre { GenreName = "Action" } },
//                                  new List<Director> { new Director { DirectorName = "Test Director" } })
//                    };

//            _mockMovieService.Setup(service => service.GetAllMovies()).Returns(movies);

//            // Act
//            _consoleManager.ViewAvailableMovies();

//            // Assert
//            _mockMovieService.Verify(service => service.GetAllMovies(), Times.Once);
//        }

//        [Test]
//        public void ViewRecommendations_UserIsAuthenticated_ReturnsListOfRecommendations()
//        {
//            // Arrange
//            var userId = 1;
//            var recommendations = new List<Recommendation>
//            {
//                new Recommendation(new Movie("Test Movie", new List<Genre> { new Genre { GenreName = "Action" } }, new List<Director> { new Director { DirectorName = "Test Director" } }), 0.9)
//            };
//            var authResult = new AuthenticationResult { IsAuthenticated = true, UserId = userId, Username = "test_user" };

//            _mockRecommendationService.Setup(service => service.GetRecommendations(userId)).Returns(recommendations);

//            // Act
//            _consoleManager.ViewRecommendations(authResult);

//            // Assert
//            _mockRecommendationService.Verify(service => service.GetRecommendations(userId), Times.Once);
//        }
//    }
//}
