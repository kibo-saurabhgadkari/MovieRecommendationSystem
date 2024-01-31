using System.Data;

namespace MovieRecommendation.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<Role> Roles { get; set; }
        public List<Movie> WatchedMovies { get; set; }
        public UserPreferences Preferences { get; set; }

        public User(int userId, string userName) 
        {
            UserId = userId;
            UserName = userName;
        }
    }
}
