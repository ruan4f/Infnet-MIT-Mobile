using NuncaCaiMobile.Models;
using Microsoft.EntityFrameworkCore;

namespace NuncaCaiMobile.Repositories
{
    public class RepositoryContext : DbContext
    {
        private string _dbPath;

        public RepositoryContext(string dbPath)
        {
            _dbPath = dbPath;
            // Create database if not there
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }

    }
}
