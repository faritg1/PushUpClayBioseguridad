using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contactopersona : BaseEntity
{
    public string Descripcion { get; set; }

    public int IdTpContactoFk { get; set; }

    public int IdPersonaFk { get; set; }

    public virtual Persona IdPersonaFkNavigation { get; set; }

    public virtual Tipocontacto IdTpContactoFkNavigation { get; set; }
}
