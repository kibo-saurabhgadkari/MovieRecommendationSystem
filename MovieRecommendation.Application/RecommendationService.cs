using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Repository;

namespace MovieRecommendation.Application
{
    public class RecommendationService
    {
        private readonly IMovieRepository _movieRepository;

        public RecommendationService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void GetAllMovies()
        {
            _movieRepository.GetAllMovies();
        }

        public void AddMovie(string title)
        {
            var movie = new Movie(title);
            _movieRepository.AddMovie(movie);
        }        

        public void GenerateRecommendations(User user)
        {
            var unwatchedMovies = _movieRepository.GetAllMovies().Where(m=> !user.WatchedMovies.Contains(m)).ToList();

            var recommendations = CalculateRelevanceScore(unwatchedMovies, user.Preferences);

            recommendations.Sort((a, b) => b.RelevanceScore.CompareTo(a.RelevanceScore));

            DisplayRecommendations(recommendations);
        }

        private void DisplayRecommendations(List<Recommendation> recommendations)
        {
            throw new NotImplementedException();
        }

        private List<Recommendation> CalculateRelevanceScore(List<Movie> movies, UserPreferences preferences)
        {
            var recommendations = new List<Recommendation>();

            #region CalculateRelevanceScore Advanced
            //foreach (var movie in unwatchedMovies)
            //{
            //    var score = 0;
            //    foreach (var genre in movie.Genres)
            //    {
            //        if (preferences.FavouriteGenres.Contains(genre))
            //        {
            //            score += 2;
            //        }
            //        else if (preferences.DislikedGenres.Contains(genre))
            //        {
            //            score -= 2;
            //        }
            //        else
            //        {
            //            score += 1;
            //        }
            //    }

            //    if (preferences.FavouriteActors.Contains(movie.Actor))
            //    {
            //        score += 2;
            //    }
            //    else if (preferences.DislikedActors.Contains(movie.Actor))
            //    {
            //        score -= 2;
            //    }
            //    else
            //    {
            //        score += 1;
            //    }

            //    if (preferences.FavouriteDirectors.Contains(movie.Director))
            //    {
            //        score += 2;
            //    }
            //    else if (preferences.DislikedDirectors.Contains(movie.Director))
            //    {
            //        score -= 2;
            //    }
            //    else
            //    {
            //        score += 1;
            //    }

            //    if (preferences.FavouriteWriters.Contains(movie.Writer))
            //    {
            //        score += 2;
            //    }
            //    else if (preferences.DislikedWriters.Contains(movie.Writer))
            //    {
            //        score -= 2;
            //    }
            //    else
            //    {
            //        score += 1;
            //    }

            //    if (preferences.FavouriteProducers.Contains(movie.Producer))
            //    {
            //        score += 2;
            //    }
            //    else if (preferences.DislikedProducers.Contains(movie.Producer))
            //    {
            //        score -= 2;
            //    }
            //    else
            //    {
            //        score += 1;
            //    }

            //    if (preferences.FavouriteCinematographers.Contains(movie.Cinematographer))
            //    {
            //        score += 2;
            //    }
            //    else if (preferences.DislikedCinematographers.Contains(movie.Cinematographer))
            //    {
            //        score -= 2;
            //    }
            //    else
            //    {
            //        score += 1;
            //    }

            //    if (preferences.FavouriteEditors.Contains(movie.Editor))
            //    {
            //        score += 2;
            //    }
            //    else if (preferences.DislikedEditors.Contains(movie.Editor))
            //    {
            //        score -= 2;
            //    }
            //    else
            //    {
            //        score += 1;
            //    }

            //    if (preferences.FavouriteComposers.Contains(movie.Composer))
            //    {
            //        score += 2;
            //    }
            //    else if (preferences.DislikedComposers.Contains(movie.Composer))
            //    {
            //        score -= 2;
            //    }   
            //}
            #endregion

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
            if (preferences.PreferredGenres.Contains(movie.Genre))
            {
                score += 1.0;
            }

            // Example: If the movie is directed by a preferred director, add to the score
            if (preferences.PreferredDirectors.Contains(movie.Director))
            {
                score += 0.5;
            }

            return score;
        }

        public IEnumerable<Recommendation> GetRecommendations(object userId)
        {
            throw new NotImplementedException();
        }
    }
}
