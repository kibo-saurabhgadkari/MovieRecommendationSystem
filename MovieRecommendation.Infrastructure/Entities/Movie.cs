namespace MovieRecommendation.Infrastructure.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Director> Directors { get; set; }
    }
}
