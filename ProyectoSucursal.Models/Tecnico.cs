using System;
using System.Collections.Generic;

namespace ProyectoSucursal.Models;

public partial class Tecnico
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public decimal SueldoBase { get; set; }

    public int IdSucursal { get; set; }

    public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
