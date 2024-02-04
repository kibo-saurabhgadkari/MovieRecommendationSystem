// ConsoleManager.cs
using MovieRecommendation.Application;
using MovieRecommendation.Domain.Entities;

public class ConsoleManager
{
    private readonly UserService _userService;
    private readonly MovieService _movieService;
    private readonly RecommendationService _recommendationService;

    public ConsoleManager(UserService userService, MovieService movieService, RecommendationService recommendationService)
    {
        _userService = userService;
        _movieService = movieService;
        _recommendationService = recommendationService;
    }

    // ConsoleManager.cs
    public void Run()
    {
        AuthenticationResult loggedInUser = null;

        Console.WriteLine("Welcome to the Movie Recommendation System!");

        int choice;
        do
        {
            Console.WriteLine("Choose an action\n1.Register\n2.Login");

        } while (!Int32.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 2));

        switch (choice)
        {
            case 1:
                loggedInUser = Register();
                break;
            case 2:
                loggedInUser = Login();
                break;
        }

        while (loggedInUser == null)
        {
            Console.WriteLine("Login or Registration failed. Choose an action\n1.Register\n2.Login");

            do
            {
                Console.WriteLine("Invalid input, please try again");

            } while (!Int32.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 2));

            switch (choice)
            {
                case 1:
                    loggedInUser = Register();
                    break;
                case 2:
                    loggedInUser = Login();
                    break;
            }
        }

        // Choose from available actions
        Console.WriteLine("Choose an action\n1.View Available Movies\n2.View Recommendations");

        while (!Int32.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 2))
        {
            Console.WriteLine("Invalid input, please try again");
        }

        switch (choice)
        {
            case 1:
                ViewAvailableMovies();
                break;
            case 2:
                ViewRecommendations(loggedInUser);
                break;
        }        
    }

    private void ViewRecommendations(AuthenticationResult loggedInUser)
    {
        // View Recommendations
        Console.WriteLine("Viewing Recommendations:");
        var recommendations = _recommendationService.GetRecommendations(loggedInUser.UserId);
        foreach (var recommendation in recommendations)
        {
            Console.WriteLine($"{recommendation.Movie.Title} - {recommendation.Movie.Title} - {recommendation.Movie.Title} - RelevanceScore({recommendation.RelevanceScore})");
        }
    }

    private void ViewAvailableMovies()
    {
        // Explore Movies
        var movies = _movieService.GetAllMovies();
        Console.WriteLine("Available Movies:");
        foreach (var movie in movies)
        {
            Console.WriteLine($"{movie.MovieId}. {movie.Title} - {movie.Genres} - {movie.Directors}");
        }
    }

    private AuthenticationResult Register()
    {
        // User Registration
        Console.WriteLine("Register a new user:");
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        return _userService.RegisterUser(username, password);
    }

    private MovieRecommendation.Domain.Entities.AuthenticationResult Login()
    {
        // User Login
        Console.WriteLine("Login:");
        Console.Write("Enter username: ");
        string loginUsername = Console.ReadLine();
        Console.Write("Enter password: ");
        string loginPassword = Console.ReadLine();
        var loggedInUser = _userService.LoginUser(loginUsername, loginPassword);
        return loggedInUser;
    }
}
