namespace MovieRecommendation.Domain.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }

        public Movie(string title)
        {
            Title = title;
        }
    }
}
