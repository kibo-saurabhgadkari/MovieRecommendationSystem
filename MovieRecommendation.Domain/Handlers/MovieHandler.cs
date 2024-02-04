using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Repository;

namespace MovieRecommendation.Domain.Handlers
{
    public interface IMovieHandler
    {
        Movie GetMovie(int id);
        Movie GetMovieById(int id);
        Movie GetMovieByTitle(string title);
        List<Movie> GetAllMovies();
        void AddMovie(string title, List<Genre> generes, List<Director> directors);

    }
    public class MovieHandler : IMovieHandler
    {
        private readonly IMovieRepository _movieRepository;

        public MovieHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void AddMovie(string title, List<Genre> generes,List<Director> directors)
        {
            var movie = new Movie(title, generes, directors);
            _movieRepository.AddMovie(movie);
        }

        public List<Movie> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public Movie GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
