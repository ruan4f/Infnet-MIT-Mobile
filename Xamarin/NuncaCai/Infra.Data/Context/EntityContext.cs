using DomainModel.Entities;
using Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class EntityContext : DbContext
    {
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Match> Matches { get; set; }

        public EntityContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=NuncaCai;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new PlayerConfig());
            modelBuilder.ApplyConfiguration(new MatchConfig());
           // modelBuilder.ApplyConfiguration(new MatchPlayedConfig());
        }

    }
}
