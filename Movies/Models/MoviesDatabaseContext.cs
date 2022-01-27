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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie>().HasData(

                new Movie
                {
                    MovieId = 1,
                    Title = "Interstellar",
                    Category = "Sci-fi",
                    Year = 2014,
                    Rating = "PG-13",
                    Director = "Christopher Nolan"
                },
                new Movie
                {
                    MovieId = 2,
                    Title = "Whiplash",
                    Category = "Drama",
                    Year = 2014,
                    Rating = "R",
                    Director = "Damien Chazell"
                },
                new Movie
                {
                    MovieId = 3,
                    Title = "1917",
                    Category = "War",
                    Year = 2020,
                    Rating = "R",
                    Director = "Sam Mendes"
                }
                );
        }
    }
}
