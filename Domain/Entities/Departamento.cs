using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Departamento : BaseEntity
{
    public string NombreDepar { get; set; }

    public int IdPaisFk { get; set; }

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

    public virtual Pai IdPaisFkNavigation { get; set; }
}
