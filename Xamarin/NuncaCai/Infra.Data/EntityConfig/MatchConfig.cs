using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntityConfig
{
    public class MatchConfig : IEntityTypeConfiguration<Match>
    {

        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .HasOne(d => d.Player1)
                .WithMany()
                .HasForeignKey(e => e.Player1Id)
                .IsRequired();

            builder
                .HasOne(d => d.Player2)
                .WithMany()
                .HasForeignKey(e => e.Player2Id)
                .IsRequired(); 

            builder
                .HasOne(d => d.Winner)
                .WithMany()
                .HasForeignKey(e => e.WinnerId)                
                .IsRequired();
        }

    }
}
