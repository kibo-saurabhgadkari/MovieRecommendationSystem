﻿namespace MovieRecommendation.Infrastructure.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<Role> Roles { get; set; }
        public List<Movie> WatchedMovies { get; set; }
        public UserPreferences Preferences { get; set; }
        public string Password { get; set; }

        //
    }
}
