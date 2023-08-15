using ProyectoSucursal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSucursal.BLL.Service
{
    public interface IElementoService
    {
        Task<bool> Insert(Elemento model);

        Task<bool> Update(Elemento model);

        Task<bool> Delete(int id);

        Task<Elemento> GetById(int id);

        Task<IQueryable<Elemento>> GetAll();
    }
}
