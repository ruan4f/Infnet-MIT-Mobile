using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.SQLite.EntityConfig
{
    public class MatchPlayedConfig : IEntityTypeConfiguration<MatchPlayed>
    {

        public void Configure(EntityTypeBuilder<MatchPlayed> builder)
        {
            builder.HasKey(x => new { x.MatchId, x.Player1Id, x.Player2Id });

            builder
                .HasOne(m => m.Match)
                .WithMany(t => t.MatchesPlayed)
                .HasForeignKey(m => m.MatchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(m => m.Player1)
                .WithMany(t => t.FirstMatchesPlayed)
                .HasForeignKey(m => m.Player1Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(m => m.Player2)
                .WithMany(t => t.SecondMatchesPlayed)
                .HasForeignKey(m => m.Player2Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(m => m.Winner)
                .WithMany(t => t.WinnerMatchesPlayed)
                .HasForeignKey(m => m.WinnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
