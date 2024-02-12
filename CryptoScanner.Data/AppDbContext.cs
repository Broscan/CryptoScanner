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




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CryptoScannerDb;Trusted_Connection=True");
        }


    }
}
