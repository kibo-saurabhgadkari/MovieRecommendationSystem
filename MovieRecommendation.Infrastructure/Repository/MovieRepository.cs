using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Repository;
using MovieRecommendation.Infrastructure.Mappings;

namespace MovieRecommendation.Infrastructure.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public void AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAllMovies()
        {

            var movies = _context.Movies.ToList();
            return movies.ToDomain();
        }

        public Movie GetMovieById(int movieId)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
