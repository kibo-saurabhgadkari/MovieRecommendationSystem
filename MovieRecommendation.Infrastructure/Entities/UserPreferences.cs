namespace MovieRecommendation.Infrastructure.Entities
{
    public class UserPreferences
    {
        public List<string> PreferredGenres { get; set; }
        public List<string> PreferredDirectors { get; set; }
    }
}