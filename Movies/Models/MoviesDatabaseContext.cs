using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class MoviesDatabaseContext : DbContext
    {
        public MoviesDatabaseContext (DbContextOptions<MoviesDatabaseContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<Movie> MovieSet { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );


            mb.Entity<Movie>().HasData(

                new Movie
                {
                    MovieId = 1,
                    Title = "Interstellar",
                    CategoryId = 1,
                    Year = 2014,
                    Rating = "PG-13",
                    Director = "Christopher Nolan"
                },
                new Movie
                {
                    MovieId = 2,
                    Title = "Whiplash",
                    CategoryId = 3,
                    Year = 2014,
                    Rating = "R",
                    Director = "Damien Chazell"
                },
                new Movie
                {
                    MovieId = 3,
                    Title = "1917",
                    CategoryId = 1,
                    Year = 2020,
                    Rating = "R",
                    Director = "Sam Mendes"
                }
                );
        }
    }
}
