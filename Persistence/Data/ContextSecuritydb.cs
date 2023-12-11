using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection;
using Persistence.Entities;

namespace Persistence.Data;

public partial class ContextSecuritydb : DbContext
{
    public ContextSecuritydb()
    {
    }

    public ContextSecuritydb(DbContextOptions<ContextSecuritydb> options): base(options)
    {
    }

    public virtual DbSet<Categoriapersona> Categoriaspersonas { get; set; }

    public virtual DbSet<Ciudad> Ciudades { get; set; }

    public virtual DbSet<Contactopersona> Contactospersonas { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Direccionpersona> Direccionespersonas { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Pai> Paises { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }
    public virtual DbSet<Programacion> Programaciones { get; set; }

    public virtual DbSet<Tipocontacto> Tiposcontactos { get; set; }

    public virtual DbSet<Tipodireccion> Tiposdirecciones { get; set; }

    public virtual DbSet<Tipopersona> Tipospersonas { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}