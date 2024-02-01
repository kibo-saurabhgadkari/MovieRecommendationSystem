using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddMovie(string title)
        {
            _movieHandler.AddMovie(title);
        }
    }
}
