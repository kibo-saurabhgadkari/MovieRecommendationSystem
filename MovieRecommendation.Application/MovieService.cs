using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Handlers;

namespace MovieRecommendation.Application
{
    public class MovieService
    {
        IMovieHandler _movieHandler;

        public MovieService(IMovieHandler movieHandler)
        {
            _movieHandler = movieHandler;
        }

        public List<Movie> GetAllMovies()
        {
            return _movieHandler.GetAllMovies();
        }

        public void AddMovie(string title, List<Genre> generes, List<Director> directors)
        {
            _movieHandler.AddMovie(title, generes, directors);
        }
    }
}
