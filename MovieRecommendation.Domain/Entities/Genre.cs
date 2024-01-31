namespace MovieRecommendation.Domain.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        List<Movie> Movies { get; set; }

        public override string ToString()
        {
            return GenreName;
        }
    }
}