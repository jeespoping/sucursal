using System;
using System.Collections.Generic;

namespace ProyectoSucursal.Models;

public partial class Sucursal
{
    public int Codigo { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Tecnico> Tecnicos { get; set; } = new List<Tecnico>();
}
