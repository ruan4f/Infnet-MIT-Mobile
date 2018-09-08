using DomainModel.Entities;
using Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class EntityContext : DbContext
    {
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        
        //public EntityContext(DbContextOptions<EntityContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=NuncaCai;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerConfig());
            modelBuilder.ApplyConfiguration(new MatchConfig());
        }

    }
}
