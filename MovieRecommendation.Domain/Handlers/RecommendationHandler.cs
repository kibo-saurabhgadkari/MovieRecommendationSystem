using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.Domain.Handlers
{
    public interface IRecommendationHandler
    {
        List<Recommendation> GetRecommendations(int userId);
    }
    public class RecommendationHandler : IRecommendationHandler
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;
        public RecommendationHandler(IMovieRepository movieRepository, IUserRepository userRepository) 
        {
            _movieRepository = movieRepository;
            _userRepository = userRepository;
        }

        public List<Recommendation> GetRecommendations(int userId)
        {
            var user = _userRepository.GetUserById(userId);

            var unwatchedMovies = _movieRepository.GetAllMovies().Where(m => !user.WatchedMovies.Contains(m)).ToList();

            var recommendations = CalculateRelevanceScore(unwatchedMovies, user.Preferences);

            recommendations.Sort((a, b) => b.RelevanceScore.CompareTo(a.RelevanceScore));

            return recommendations;
        }

        private List<Recommendation> CalculateRelevanceScore(List<Movie> movies, UserPreferences preferences)
        {
            var recommendations = new List<Recommendation>();

            #region CalculateRelevanceScore Simple
            foreach (var movie in movies)
            {
                var relevanceScore = CalculateScore(movie, preferences);
                recommendations.Add(new Recommendation(movie, relevanceScore));
            }
            #endregion

            return recommendations;
        }

        private double CalculateScore(Movie movie, UserPreferences preferences)
        {
            var score = 0.0;

            // Example: If the movie genre matches the user's preferred genre, add to the score
            if (preferences.PreferredGenres.Any(p => movie.Genres.Contains(p)))
            {
                score += 1.0;
            }

            // Example: If the movie is directed by a preferred director, add to the score
            if (preferences.PreferredDirectors.Any(d => movie.Directors.Contains(d)))
            {
                score += 0.5;
            }

            return score;
        }
    }
}
