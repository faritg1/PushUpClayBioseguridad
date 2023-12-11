using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Persona : BaseEntity
{
    public int IdPerUq { get; set; }

    public string NombrePersona { get; set; }

    public DateOnly FechaReg { get; set; }

    public int IdTpPersonaFk { get; set; }

    public int IdCategoriaP { get; set; }

    public int IdCiudadFk { get; set; }

    public virtual ICollection<Contactopersona> Contactopersonas { get; set; } = new List<Contactopersona>();

    public virtual ICollection<Contrato> ContratoIdClienteFkNavigations { get; set; } = new List<Contrato>();

    public virtual ICollection<Contrato> ContratoIdEmpleadoFkNavigations { get; set; } = new List<Contrato>();

    public virtual ICollection<Direccionpersona> Direccionpersonas { get; set; } = new List<Direccionpersona>();

    public virtual Categoriapersona IdCategoriaPNavigation { get; set; }

    public virtual Ciudad IdCiudadFkNavigation { get; set; }

    public virtual Tipopersona IdTpPersonaFkNavigation { get; set; }
}
