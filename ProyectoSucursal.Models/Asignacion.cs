using System;
using System.Collections.Generic;

namespace ProyectoSucursal.Models;

public partial class Asignacion
{
    public int Id { get; set; }

    public int IdElemento { get; set; }

    public int IdTecnico { get; set; }

    public int Cantidad { get; set; }

    public virtual Elemento IdElementoNavigation { get; set; } = null!;

    public virtual Tecnico IdTecnicoNavigation { get; set; } = null!;
}
