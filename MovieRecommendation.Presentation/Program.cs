// Program.cs
using Microsoft.Extensions.DependencyInjection;
using MovieRecommendation.Application;
using MovieRecommendation.Domain.Handlers;
using MovieRecommendation.Domain.Repository;
using MovieRecommendation.Infrastructure;
using MovieRecommendation.Infrastructure.Repository;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ConsoleManager>()
            .AddSingleton<UserService>() 
            .AddSingleton<MovieService>()
            .AddSingleton<RecommendationService>()
            .AddScoped<IMovieRepository, MovieRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IMovieHandler, MovieHandler>()
            .AddScoped<IRecommendationHandler, RecommendationHandler>()
            .AddDbContext<MovieDbContext>()
            .BuildServiceProvider();

        var consoleManager = serviceProvider.GetRequiredService<ConsoleManager>();
        consoleManager.Run();
    }
}
