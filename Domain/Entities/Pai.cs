﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Pai : BaseEntity
{
    public string NombrePais { get; set; }

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
