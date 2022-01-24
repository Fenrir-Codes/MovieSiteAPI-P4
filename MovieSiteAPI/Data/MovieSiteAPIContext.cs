using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieSiteAPI.Models;

namespace MovieSiteAPI.Data
{
    public class MovieSiteAPIContext : DbContext
    {
        public MovieSiteAPIContext (DbContextOptions<MovieSiteAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MovieSiteAPI.Models.Profile> Profile { get; set; }

        public DbSet<MovieSiteAPI.Models.Director> Director { get; set; }

        public DbSet<MovieSiteAPI.Models.Order> Order { get; set; }

        public DbSet<MovieSiteAPI.Models.Movie> Movie { get; set; }

        public DbSet<MovieSiteAPI.Models.PaymentDetails> PaymentDetails { get; set; }
    }
}
