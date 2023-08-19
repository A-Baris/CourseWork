using Microsoft.EntityFrameworkCore;
using MoviePage.Models;

namespace MoviePage.Context
{
    public class MovieContext : DbContext
    {
            public DbSet<Movie> Movies { get; set; }
            public DbSet<Director> Directors { get; set; }
            public DbSet<Cast> Casts { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<MovieAndCast> MoviesAndCasts { get; set; }
            public DbSet<MovieAndCategory> MoviesAndCategories { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("server=DESKTOP-KUQ9PNH;database=MovieDB;uid=sa;pwd=1234;TrustServerCertificate=True");
                }

                base.OnConfiguring(optionsBuilder);
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<MovieAndCategory>().HasKey(x => new { x.MovieId, x.CategoryId });
                modelBuilder.Entity<MovieAndCast>().HasKey(x => new { x.MovieId, x.CastId });

                modelBuilder.Entity<Director>()
                    .HasData(
                    new Director { Id = 1, FirstName = "Peter", LasttName = "Jackson" },
                    new Director { Id = 2, FirstName = "Martin", LasttName = "Scorsese" });
                modelBuilder.Entity<Movie>()
                .HasData(
                    new Movie { Id = 1, MovieName = "Lord of the rings I", PublishedDate = 2001, DirectorId = 1, TrailerHttp = "https://www.youtube.com/embed/V75dMMIW2B4", Description = "The Lord of the Rings is the saga of a group of sometimes reluctant heroes who set forth to save their world from consummate evil. Its many worlds and creatures were drawn from Tolkien's extensive knowledge of philology and folklore." },
                    new Movie { Id = 2, MovieName = "Shutter Island", PublishedDate = 2010, DirectorId = 2, TrailerHttp = "https://www.youtube.com/embed/5iaYLCiq5RM", Description = "Plot. In 1954, U.S. Marshal Edward \"Teddy\" Daniels and his new partner Chuck Aule travel to Ashecliffe Hospital for the criminally insane on Shutter Island, Boston Harbor to investigate the disappearance of Rachel Solando, a patient of the hospital who had previously drowned her three children." });

                modelBuilder.Entity<Cast>()
               .HasData(
                    new Cast { Id = 1, FirstName = "Elijah", LastName = "Wood" },
                    new Cast { Id = 2, FirstName = "Leonardo", LastName = "DiCaprio" },
                    new Cast { Id = 3, FirstName = "Liv", LastName = "Tyler" });
                modelBuilder.Entity<Category>()
                    .HasData(

                    new Category { Id = 1, CategoryName = "Science-Fiction" },
                    new Category { Id = 2, CategoryName = "Drama" });

                modelBuilder.Entity<MovieAndCategory>()
                    .HasData(
                     new MovieAndCategory { MovieId = 1, CategoryId = 1 },
                      new MovieAndCategory { MovieId = 2, CategoryId = 2 });
                modelBuilder.Entity<MovieAndCast>()
                    .HasData(

                    new MovieAndCast { MovieId = 1, CastId = 1 },
                    new MovieAndCast { MovieId = 2, CastId = 2 },
                    new MovieAndCast { MovieId = 1, CastId = 3 });


                base.OnModelCreating(modelBuilder);
            }
        }
}
