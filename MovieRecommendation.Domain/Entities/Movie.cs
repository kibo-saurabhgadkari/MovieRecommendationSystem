using System.IO;

namespace MovieRecommendation.Domain.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Director> Directors { get; set; }

        public Movie(string title)
        {
            Title = title;
        }
    }
}
