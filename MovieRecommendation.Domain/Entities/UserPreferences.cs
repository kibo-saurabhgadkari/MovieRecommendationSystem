namespace MovieRecommendation.Domain.Entities
{
    public class UserPreferences
    {
        public int UserPreferencesId { get; set; }
        public int UserId { get; set; } // Foreign key to User
        public List<Genre> PreferredGenres { get; set; }
        public List<Director> PreferredDirectors { get; set; }
    }
}