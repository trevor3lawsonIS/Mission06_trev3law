using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_trev3law.Models
{
    public class MovieContext : DbContext
    {
        // Constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            //leave blank for now
        }

        public DbSet<Movie> Movie { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieID = 1,
                    Category = "Action",
                    Title = "The Dark Knight",
                    Year = 2013,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_To = "Josh",
                    Notes = "Great Movie"
                },
                new Movie
                {
                    MovieID = 2,
                    Category = "Rom/Com",
                    Title = "Crazy Stupid Love",
                    Year = 2013,
                    Director = "Some Guy",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_To = "Ashley",
                    Notes = "Funny Movie"
                },
                new Movie
                {
                    MovieID = 3,
                    Category = "Action",
                    Title = "Top Gun Maverick",
                    Year = 2022,
                    Director = "Tom Cruise",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_To = "Me",
                    Notes = "The Best Movie"
                }
                );
        }
    }

}
