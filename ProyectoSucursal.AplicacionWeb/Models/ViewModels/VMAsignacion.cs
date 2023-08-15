using ProyectoSucursal.Models;

namespace ProyectoSucursal.AplicacionWeb.Models.ViewModels
{
    public class VMAsignacion
    {
        public int Id { get; set; }

        public int IdElemento { get; set; }

        public int IdTecnico { get; set; }

        public int Cantidad { get; set; }

        public virtual Elemento IdElementoNavigation { get; set; } = null!;

        public virtual Tecnico IdTecnicoNavigation { get; set; } = null!;
    }
}
