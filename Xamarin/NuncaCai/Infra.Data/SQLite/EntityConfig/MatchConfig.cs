using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.SQLite.EntityConfig
{
    public class MatchConfig : IEntityTypeConfiguration<Match>
    {

        public void Configure(EntityTypeBuilder<Match> builder)
        {

            //builder
            //    .HasOne(m => m.Player1)
            //    .WithMany(t => t.FirstMatches)
            //    .HasForeignKey(m => m.Player1Id)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .HasOne(m => m.Player2)
            //    .WithMany(t => t.SecondMatches)
            //    .HasForeignKey(m => m.Player2Id)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .HasOne(m => m.Winner)
            //    .WithMany(t => t.WinnerMatches)
            //    .HasForeignKey(m => m.WinnerId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
