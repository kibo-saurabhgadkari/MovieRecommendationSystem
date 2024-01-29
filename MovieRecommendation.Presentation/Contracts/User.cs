namespace MovieRecommendation.Presentation.Contracts
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
        public List<Movie> WatchedMovies { get; set; }
        public UserPreferences Preferences { get; set; }
    }
}
