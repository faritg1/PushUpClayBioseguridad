using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DireccionPersonaConfiguration : IEntityTypeConfiguration<Direccionpersona>
    {
        public void Configure(EntityTypeBuilder<Direccionpersona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("direccionpersona");

            builder.HasIndex(e => e.IdPersonaFk, "FkPersona");

            builder.HasIndex(e => e.IdTpDireccionFk, "FkTpDireccion");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Direccion).HasMaxLength(100);

            builder.HasOne(d => d.IdPersonaFkNavigation).WithMany(p => p.Direccionpersonas)
                .HasForeignKey(d => d.IdPersonaFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkPersona");

            builder.HasOne(d => d.IdTpDireccionFkNavigation).WithMany(p => p.Direccionpersonas)
                .HasForeignKey(d => d.IdTpDireccionFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkTpDireccion");
        }
    }
}