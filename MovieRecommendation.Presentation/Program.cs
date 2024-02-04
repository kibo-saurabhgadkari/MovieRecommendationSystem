// Program.cs
using Microsoft.Extensions.DependencyInjection;
using MovieRecommendation.Application;
using MovieRecommendation.Domain.Handlers;
using MovieRecommendation.Domain.Repository;
using MovieRecommendation.Domain.Services;
using MovieRecommendation.Infrastructure;
using MovieRecommendation.Infrastructure.Repository;
using MovieRecommendation.Presentation;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ConsoleManager>()
            .AddSingleton<UserService>() 
            .AddSingleton<MovieService>()
            .AddSingleton<RecommendationService>()
            .AddSingleton<RegistrationService>()
            .AddScoped<IMovieRepository, MovieRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IMovieHandler, MovieHandler>()
            .AddScoped<IRecommendationHandler, RecommendationHandler>()
            .AddSingleton<AuthenticationService>()
            .AddDbContext<MovieDbContext>()
            .BuildServiceProvider();
        
        AutoMapperConfig.Initialize();

        var consoleManager = serviceProvider.GetRequiredService<ConsoleManager>();
        consoleManager.Run();
    }
}
