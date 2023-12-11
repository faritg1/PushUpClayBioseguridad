using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("ciudad");

            builder.HasIndex(e => e.IdDeparFk, "FkDepar");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.NombreCiudad)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.IdDeparFkNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdDeparFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkDepar");
        }
    }
}