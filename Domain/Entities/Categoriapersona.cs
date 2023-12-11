﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Categoriapersona : BaseEntity
{
    public string NombreCategoria { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
