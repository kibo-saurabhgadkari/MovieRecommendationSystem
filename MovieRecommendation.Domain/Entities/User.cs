﻿namespace MovieRecommendation.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<Role> Roles { get; set; }
        public List<Movie> WatchedMovies { get; set; }
        public UserPreferences Preferences { get; set; }
        public string Password { get; set; }

        public User(string userName, string password) 
        {
            UserName = userName;
            Password = password;
        }
    }
}
