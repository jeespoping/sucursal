using ProyectoSucursal.Models;

namespace ProyectoSucursal.AplicacionWeb.Models.ViewModels
{
    public class VMTecnico
    {
        public int Id { get; set; }

        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public decimal SueldoBase { get; set; }

        public int IdSucursal { get; set; }

        public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();

        public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
    }
}
