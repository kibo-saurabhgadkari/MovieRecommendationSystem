// Program.cs
using Microsoft.Extensions.DependencyInjection;
using MovieRecommendation.Application;
using MovieRecommendation.Domain.Repository;
using MovieRecommendation.Infrastructure;
using MovieRecommendation.Infrastructure.Repository;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ConsoleManager>()
            .AddSingleton<UserService>()  // Assuming you have a UserService in the Application layer
            .AddSingleton<MovieService>() // Assuming you have a MovieService in the Application layer
            .AddSingleton<RecommendationService>() // Assuming you have a RecommendationService in the Application layer
            .AddScoped<IMovieRepository, MovieRepository>()
            .AddDbContext<MovieDbContext>()
            .BuildServiceProvider();

        var consoleManager = serviceProvider.GetRequiredService<ConsoleManager>();
        consoleManager.Run();
    }
}
