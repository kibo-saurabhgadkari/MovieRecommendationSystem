// ConsoleManager.cs
using MovieRecommendation.Application;
using System;

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
        Console.WriteLine("Welcome to the Movie Recommendation System!");

        // User Registration
        Console.WriteLine("Register a new user:");
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        _userService.RegisterUser(username, password);

        // User Login
        Console.WriteLine("Login:");
        Console.Write("Enter username: ");
        string loginUsername = Console.ReadLine();
        Console.Write("Enter password: ");
        string loginPassword = Console.ReadLine();
        var loggedInUser = _userService.LoginUser(loginUsername, loginPassword);

        // Explore Movies
        var movies = _movieService.GetMovies();
        Console.WriteLine("Available Movies:");
        foreach (var movie in movies)
        {
            Console.WriteLine($"{movie.MovieId}. {movie.Title} - {movie.Genre} - {movie.Director}");
        }

        // View Recommendations
        Console.WriteLine("Viewing Recommendations:");
        var recommendations = _recommendationService.GetRecommendations(loggedInUser.UserId);
        foreach (var recommendation in recommendations)
        {
            Console.WriteLine($"{recommendation.Movie.Title} - {recommendation.Movie.Title} - {recommendation.Movie.Title} - RelevanceScore({recommendation.RelevanceScore})");
        }
    }

}
