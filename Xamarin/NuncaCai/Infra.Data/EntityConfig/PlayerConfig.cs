using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntityConfig
{
    public class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(e => e.PlayerId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Point)
                .IsRequired();

            builder.Property(e => e.RegistrationDate)
                .IsRequired();

            builder.HasMany(f => f.FirstMatches)
                .WithOne(f => f.Player1);

            builder.HasMany(f => f.SecondMatches)
                .WithOne(f => f.Player2);

            builder.HasMany(f => f.WinnerMatches)
                .WithOne(f => f.Winner);
        }
    }
}
