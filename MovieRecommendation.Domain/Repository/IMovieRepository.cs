using MovieRecommendation.Domain.Entities;

namespace MovieRecommendation.Domain.Repository
{
    public interface IMovieRepository
    {
        void AddMovie(Movie movie);
        void DeleteMovie(Movie movie);
        void UpdateMovie(Movie movie);
        Movie GetMovieById(int movieId);
        Movie GetMovieByTitle(string title);
        List<Movie> GetAllMovies();

    }
}
