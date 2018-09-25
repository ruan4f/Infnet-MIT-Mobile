using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.SQLite.EntityConfig
{
    public class PlayerConfig : IEntityTypeConfiguration<Player>
    {

        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(x => x.PlayerId);
            builder.Property(x => x.Name);
            builder.Property(x => x.RegistrationDate);

            //builder
            //    .HasMany(m => m.FirstMatches)
            //    .WithOne(m => m.Player1)
            //    .HasForeignKey(m => m.Player1Id);

            //builder
            //    .HasMany(m => m.SecondMatches)
            //    .WithOne(m => m.Player2)
            //    .HasForeignKey(m => m.Player2Id);

            //builder
            //    .HasMany(m => m.WinnerMatches)
            //    .WithOne(m => m.Winner)
            //    .HasForeignKey(m => m.WinnerId);
        }
    }
}
