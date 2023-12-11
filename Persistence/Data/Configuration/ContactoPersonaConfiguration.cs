using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContactoPersonaConfiguration : IEntityTypeConfiguration<Contactopersona>
    {
        public void Configure(EntityTypeBuilder<Contactopersona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contactopersona");

            builder.HasIndex(e => e.IdPersonaFk, "FkPersonaC");

            builder.HasIndex(e => e.IdTpContactoFk, "FkTpContacto");

            builder.HasIndex(e => e.Descripcion, "UqCtPersona").IsUnique();

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Descripcion).HasMaxLength(100);

            builder.HasOne(d => d.IdPersonaFkNavigation).WithMany(p => p.Contactopersonas)
                .HasForeignKey(d => d.IdPersonaFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkPersonaC");

            builder.HasOne(d => d.IdTpContactoFkNavigation).WithMany(p => p.Contactopersonas)
                .HasForeignKey(d => d.IdTpContactoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkTpContacto");
        }
    }
}