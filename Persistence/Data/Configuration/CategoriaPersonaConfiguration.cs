using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CategoriaPersonaConfiguration : IEntityTypeConfiguration<Categoriapersona>
    {
        public void Configure(EntityTypeBuilder<Categoriapersona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("categoriapersona");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.NombreCategoria)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}