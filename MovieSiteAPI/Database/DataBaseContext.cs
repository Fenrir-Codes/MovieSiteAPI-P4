using Microsoft.EntityFrameworkCore;
using MovieSiteAPI.Models;

namespace MovieSiteAPI.Database
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<Order> Order { get; set;}
        public DbSet<Movie> Movie { get; set;}
        public DbSet<Director> Director { get; set;}
        public DbSet<PaymentDetails> PaymentDetails { get; set;}
        public DbSet<Profile> Profile { get; set;}
    }
}
