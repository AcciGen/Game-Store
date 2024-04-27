using Game_Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store.Infrastructure.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Poster)
                .IsRequired();

            builder
                .Property(x => x.Price)
                .IsRequired();

            builder
                .Property(x => x.Trailer)
                .IsRequired();

            builder
                .Property(x => x.Photos)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .IsRequired();

            builder
                .Property(x => x.Genres)
                .IsRequired();

            builder
                .Property(x => x.RatingsGuide)
                .IsRequired();

            builder
                .Property(x => x.ReleaseDate)
                .IsRequired();

            builder
                .Property(x => x.Developer)
                .HasMaxLength(80)
                .IsRequired();

            builder
                .Property(x => x.Publisher)
                .HasMaxLength(80)
                .IsRequired();

            builder
                .Property(x => x.Platform)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
