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
    public class SystemRequirementConfiguration : IEntityTypeConfiguration<SystemRequirement>
    {
        public void Configure(EntityTypeBuilder<SystemRequirement> builder)
        {
            builder.Property(x => x.OS)
                .IsRequired();

            builder.Property(x => x.Memory)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.DirectX)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(x => x.DiskSpace)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.LanguagesSupported)
                .IsRequired();

            builder.Property(x => x.CPU)
                .IsRequired();
        }
    }
}
