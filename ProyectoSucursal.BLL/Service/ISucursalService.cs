using ProyectoSucursal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSucursal.BLL.Service
{
    public interface ISucursalService
    {
        Task<bool> Insert(Sucursal model);

        Task<bool> Update(Sucursal model);

        Task<bool> Delete(int id);

        Task<Sucursal> GetById(int id);

        Task<IQueryable<Sucursal>> GetAll();

        Task<Sucursal> GetByName(string name);
    }
}
