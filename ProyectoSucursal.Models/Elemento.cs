using System;
using System.Collections.Generic;

namespace ProyectoSucursal.Models;

public partial class Elemento
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();
}
