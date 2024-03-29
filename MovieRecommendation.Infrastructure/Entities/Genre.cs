﻿namespace MovieRecommendation.Infrastructure.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public List<Movie> Movies { get; set; }
    }
}