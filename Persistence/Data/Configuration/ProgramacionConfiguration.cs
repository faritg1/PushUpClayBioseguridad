using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Data.Configuration
{
    public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
    {
        public void Configure(EntityTypeBuilder<Programacion> builder)
        {
            builder
                .HasNoKey()
                .ToTable("programacion");

            builder.HasIndex(e => e.IdContratoFk, "FkContrato");

            builder.HasIndex(e => e.IdEmpleadoFk, "FkEmpleadoO");

            builder.HasIndex(e => e.IdTurnoFk, "FkTurno");

            builder.HasOne(d => d.IdContratoFkNavigation).WithMany()
                .HasForeignKey(d => d.IdContratoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkContrato");

            builder.HasOne(d => d.IdEmpleadoFkNavigation).WithMany()
                .HasForeignKey(d => d.IdEmpleadoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkEmpleadoO");

            builder.HasOne(d => d.IdTurnoFkNavigation).WithMany()
                .HasForeignKey(d => d.IdTurnoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkTurno");
        }
    }
}