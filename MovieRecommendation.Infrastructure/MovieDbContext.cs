using Microsoft.EntityFrameworkCore;
using MovieRecommendation.Infrastructure.Entities;

namespace MovieRecommendation.Infrastructure
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPreferences> UserPreferences { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MovieRecommendation;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //// Genres
            //modelBuilder.Entity<Genre>().HasData(
            //    new Genre { GenreId = 1, GenreName = "Action" },
            //    new Genre { GenreId = 2, GenreName = "Drama" }
            //    // Add more genres as needed
            //);

            //// Directors
            //modelBuilder.Entity<Director>().HasData(
            //    new Director { DirectorId = 1, DirectorName = "Steven Spielberg" },
            //    new Director { DirectorId = 2, DirectorName = "Christopher Nolan" }
            //    // Add more directors as needed
            //);

            //// Movies
            //modelBuilder.Entity<Movie>().HasData(
            //    new Movie { MovieId = 1, Title = "Saving Private Ryan" },
            //    new Movie { MovieId = 2, Title = "The Dark Knight" }
            //    // Add more movies as needed
            //);

            //// DirectorMovie (Join Table)
            //modelBuilder.Entity<DirectorMovie>().HasData(
            //    new { DirectorsDirectorId = 1, MoviesMovieId = 1 },
            //    new { DirectorsDirectorId = 2, MoviesMovieId = 2 }
            //    // Add more entries as needed
            //);

            //// Users
            //modelBuilder.Entity<User>().HasData(
            //    new User { UserId = 1, UserName = "sgadkari", Password = "password" },
            //    new User { UserId = 2, UserName = "sonal", Password = "password" }
            //    // Add more users as needed
            //);

            //// User Preferences
            //modelBuilder.Entity<UserPreferences>().HasData(
            //    new UserPreferences { UserPreferencesId = 1, UserId = 1 },
            //    new UserPreferences { UserPreferencesId = 2, UserId = 2 }
            //    // Add more preferences as needed
            //);

            // Add relationships for watched movies, roles, etc.


            //modelBuilder.Entity<Movie>().HasData(
            //    // Movie 1
            //    new Movie
            //    {
            //        MovieId = 1,
            //        Title = "The Shawshank Redemption",
            //        Genres = new List<Genre> { new Genre { GenreId = 2, GenreName = "Drama" } },
            //        Directors = new List<Director> { new Director { DirectorId = 2, DirectorName = "Christopher Nolan" } }
            //    },
            //    // Movie 2
            //    new Movie
            //    {
            //        MovieId = 2,
            //        Title = "The Godfather",
            //        Genres = new List<Genre> { new Genre { GenreId = 1, GenreName = "Action" } },
            //        Directors = new List<Director> { new Director { DirectorId = 3, DirectorName = "Quentin Tarantino" } }
            //    },
            //    // Movie 3
            //    new Movie
            //    {
            //        MovieId = 3,
            //        Title = "Pulp Fiction",
            //        Genres = new List<Genre> { new Genre { GenreId = 7, GenreName = "Crime" }, new Genre { GenreId = 4, GenreName = "Thriller" } },
            //        Directors = new List<Director> { new Director { DirectorId = 3, DirectorName = "Quentin Tarantino" } }
            //    },
            //    // Movie 4
            //    new Movie
            //    {
            //        MovieId = 4,
            //        Title = "The Dark Knight",
            //        Genres = new List<Genre> { new Genre { GenreId = 1, GenreName = "Action" }, new Genre { GenreId = 5, GenreName = "Science Fiction" } },
            //        Directors = new List<Director> { new Director { DirectorId = 2, DirectorName = "Christopher Nolan" } }
            //    },
            //    // Movie 5
            //    new Movie
            //    {
            //        MovieId = 5,
            //        Title = "Schindler's List",
            //        Genres = new List<Genre> { new Genre { GenreId = 2, GenreName = "Drama" }, new Genre { GenreId = 8, GenreName = "History" } },
            //        Directors = new List<Director> { new Director { DirectorId = 1, DirectorName = "Steven Spielberg" } }
            //    });

            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        UserId = 1,
            //        UserName = "sgadkari",
            //        Password = "password",
            //        Preferences = new UserPreferences
            //        {
            //            UserPreferencesId = 1,
            //            UserId = 1,
            //            PreferredGenres = new List<Genre> { new Genre { GenreId = 2, GenreName = "Drama" } },
            //            PreferredDirectors = new List<Director> { new Director { DirectorId = 2, DirectorName = "Christopher Nolan" } }
            //        },
            //        Roles = new List<Role> { new Role { RoleId = 1, RoleName = "Admin" } }
            //    }, 
            //    new User {
            //        UserId = 1,
            //        UserName = "sonal",
            //        Password = "password",
            //        Preferences = new UserPreferences
            //        {
            //            UserPreferencesId = 1,
            //            UserId = 1,
            //            PreferredGenres = new List<Genre> { new Genre { GenreId = 2, GenreName = "Action" } },
            //            PreferredDirectors = new List<Director> { new Director { DirectorId = 2, DirectorName = "Christopher Nolan" } }
            //        },
            //        Roles = new List<Role> { new Role { RoleId = 1, RoleName = "Admin" } }
            //    });
            //modelBuilder.Entity<Role>().HasData(
            //                   new Role { RoleId = 1, RoleName = "Admin" },
            //                                  new Role { RoleId = 2, RoleName = "User" }
            //                                             );
            //modelBuilder.Entity<Genre>().HasData(
            //                   new Genre { GenreId = 1, GenreName = "Action" },
            //                                  new Genre { GenreId = 2, GenreName = "Drama" },
            //                                                 new Genre { GenreId = 3, GenreName = "Comedy" },
            //                                                                new Genre { GenreId = 4, GenreName = "Thriller" },
            //                                                                               new Genre { GenreId = 5, GenreName = "Science Fiction" },
            //                                                                                              new Genre { GenreId = 6, GenreName = "Horror" },
            //                                                                                                             new Genre { GenreId = 7, GenreName = "Crime" },
            //                                                                                                                            new Genre { GenreId = 8, GenreName = "History" }
            //                                                                                                                                       );
        }
    }    
}
