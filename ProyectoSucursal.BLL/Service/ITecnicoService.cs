using ProyectoSucursal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSucursal.BLL.Service
{
    public interface ITecnicoService
    {
        Task<bool> Insert(Tecnico model);

        Task<bool> Update(Tecnico model);

        Task<bool> Delete(int id);

        Task<Tecnico> GetById(int id);

        Task<Tecnico> GetByCodigo(string codigo);

        Task<Tecnico> GetByLast();

        Task<IQueryable<Tecnico>> GetAll();
    }
}
