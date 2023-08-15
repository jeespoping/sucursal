using ProyectoSucursal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSucursal.BLL.Service
{
    public interface IAsignacionService
    {
        Task<bool> Insert(Asignacion model);

        Task<bool> Update(Asignacion model);

        Task<bool> Delete(int id);

        Task<Asignacion> GetById(int id);

        Task<IQueryable<Asignacion>> GetAll();

        Task<bool> DeleteByTecnico(int id);

        Task<IQueryable<Asignacion>> GetByTecnico(int id);
    }
}
