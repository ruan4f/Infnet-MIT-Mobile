using DomainModel.Entities;
using Infra.Data.SQLServer.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.SQLServer.Context
{
    public class EntitySQLContext : DbContext
    {
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Match> Matches { get; set; }

        public string DbPath { get; set; }

        public EntitySQLContext()
        {
            DbPath = @"Data Source=.\SQLEXPRESS;Initial Catalog=NuncaCai;Integrated Security=True;";

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbPath);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MatchConfig());
        }

    }
}
