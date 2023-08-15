using ProyectoSucursal.Models;

namespace ProyectoSucursal.AplicacionWeb.Models.ViewModels
{
    public class VMElemento
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();
    }
}
