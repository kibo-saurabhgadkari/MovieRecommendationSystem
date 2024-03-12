// ConsoleManager.cs
using MovieRecommendation.Application;
using MovieRecommendation.Domain.Entities;

public class ConsoleManager
{
    private readonly IUserService _userService;
    private readonly IMovieService _movieService;
    private readonly IRecommendationService _recommendationService;
    private readonly IConsoleWrapper _consoleWrapper;


    public ConsoleManager(IUserService userService, IMovieService movieService, IRecommendationService recommendationService, IConsoleWrapper consoleWrapper)
    {
        _userService = userService;
        _movieService = movieService;
        _recommendationService = recommendationService;
        _consoleWrapper = consoleWrapper;
    }

    // ConsoleManager.cs
    public void Run()
    {
        AuthenticationResult result = null;

        _consoleWrapper.WriteLine("Welcome to the Movie Recommendation System!");

        int choice;
        do
        {
            _consoleWrapper.WriteLine("Choose an action\n1.Register\n2.Login");

        } while (!Int32.TryParse(_consoleWrapper.ReadLine(), out choice) || (choice < 1 || choice > 2));

        switch (choice)
        {
            case 1:
                result = Register();
                break;
            case 2:
                result = Login();
                break;
        }

        while (result == null || !result.IsAuthenticated)
        {
            _consoleWrapper.WriteLine("Login or Registration failed. Choose an action\n1.Register\n2.Login");

            do
            {
                _consoleWrapper.WriteLine("Invalid input, please try again");

            } while (!Int32.TryParse(_consoleWrapper.ReadLine(), out choice) || (choice < 1 || choice > 2));

            switch (choice)
            {
                case 1:
                    result = Register();
                    break;
                case 2:
                    result = Login();
                    break;
            }
        }

        // Choose from available actions
        _consoleWrapper.WriteLine("Choose an action\n1.View Available Movies\n2.View Recommendations");

        while (!Int32.TryParse(_consoleWrapper.ReadLine(), out choice) || (choice < 1 || choice > 2))
        {
            _consoleWrapper.WriteLine("Invalid input, please try again");
        }

        switch (choice)
        {
            case 1:
                ViewAvailableMovies();
                break;
            case 2:
                ViewRecommendations(result);
                break;
        }        
    }

    internal void ViewRecommendations(AuthenticationResult loggedInUser)
    {
        // View Recommendations
        _consoleWrapper.WriteLine("Viewing Recommendations:");
        var recommendations = _recommendationService.GetRecommendations(loggedInUser.UserId);
        foreach (var recommendation in recommendations)
        {
            _consoleWrapper.WriteLine($"{recommendation.Movie.Title} - {recommendation.Movie.Title} - {recommendation.Movie.Title} - RelevanceScore({recommendation.RelevanceScore})");
        }
    }

    internal void ViewAvailableMovies()
    {
        // Explore Movies
        var movies = _movieService.GetAllMovies();
        _consoleWrapper.WriteLine("Available Movies:");
        foreach (var movie in movies)
        {
            _consoleWrapper.WriteLine($"{movie.MovieId}. {movie.Title} - {movie.Genres} - {movie.Directors}");
        }
    }

    internal AuthenticationResult Register()
    {
        // User Registration
        _consoleWrapper.WriteLine("Register a new user:");
        _consoleWrapper.Write("Enter username: ");
        string username = _consoleWrapper.ReadLine();
        _consoleWrapper.Write("Enter password: ");
        string password = _consoleWrapper.ReadLine();
        return _userService.RegisterUser(username, password);
    }

    internal MovieRecommendation.Domain.Entities.AuthenticationResult Login()
    {
        // User Login
        _consoleWrapper.WriteLine("Login:");
        _consoleWrapper.Write("Enter username: ");
        string loginUsername = _consoleWrapper.ReadLine();
        _consoleWrapper.Write("Enter password: ");
        string loginPassword = _consoleWrapper.ReadLine();
        var loggedInUser = _userService.LoginUser(loginUsername, loginPassword);
        return loggedInUser;
    }

    public interface IConsoleWrapper
    {
        string ReadLine();
        void WriteLine(string value);
        void Write(string value);
    }

    public class ConsoleWrapper : IConsoleWrapper
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void Write(string value)
        {
            Console.Write(value);
        }
    }
}
