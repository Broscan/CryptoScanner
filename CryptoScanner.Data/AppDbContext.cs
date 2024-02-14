using CryptoScanner.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoScanner.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CryptoModel> Currency { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CryptoModel>().HasData(
                new CryptoModel()
                {
                    Id = 1,
                    ApiId = "bitcoin",
                    Name = "Bitcoin",
                    Price = 514135
                },
                new CryptoModel()
                {
                    Id = 2,
                    ApiId = "dogecoin",
                    Name = "Dogecoin",
                    Price = (decimal?)0.854076
                },
                new CryptoModel()
                {
                    Id = 3,
                    ApiId = "tether",
                    Name = "Tether",
                    Price = (decimal?)10.59
                },
                new CryptoModel()
                {
                    Id = 4,
                    ApiId = "solana",
                    Name = "Solana",
                    Price = (decimal?)1158.27
                },
                new CryptoModel()
                {
                    Id = 5,
                    ApiId = "cardano",
                    Name = "Cardano",
                    Price = (decimal?)5.7
                });



        }
    }
}
