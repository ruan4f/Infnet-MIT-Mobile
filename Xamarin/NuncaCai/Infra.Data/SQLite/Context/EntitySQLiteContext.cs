using DomainModel.Entities;
using Infra.Data.SQLite.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Infra.Data.SQLite.Context
{
    public class EntitySQLiteContext : DbContext
    {
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Match> Matches { get; set; }

        public string DbPath { get; set; }

        public EntitySQLiteContext(string devicePlatform)
        {
            string dbPath = String.Empty;

            switch (devicePlatform)
            {
                case "UWP":
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                    break;
                case "iOS":
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "data", "database.sqlite");
                    break;
                case "Android":
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "database.sqlite");
                    break;
            }

            DbPath = dbPath;
            // Create database if not there
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Filename={DbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MatchPlayedConfig());
            //modelBuilder.ApplyConfiguration(new PlayerConfig());
            //modelBuilder.ApplyConfiguration(new MatchConfig());
        }
    }
}
