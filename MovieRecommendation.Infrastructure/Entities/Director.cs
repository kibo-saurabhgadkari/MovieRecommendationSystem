namespace MovieRecommendation.Infrastructure.Entities
{
    public class Director
    {
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        public List<Movie> Movies { get; set; }
    }
}