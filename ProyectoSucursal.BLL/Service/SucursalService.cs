using ProyectoSucursal.DAL.Repositories;
using ProyectoSucursal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSucursal.BLL.Service
{
    public class SucursalService : ISucursalService
    {
        private readonly IGenericRepository<Sucursal> _sucursalRepo;
        public SucursalService(IGenericRepository<Sucursal> sucursalRepo)
        {
            _sucursalRepo = sucursalRepo;
        }
        public async Task<bool> Delete(int id)
        {
            return await _sucursalRepo.Delete(id);
        }

        public async Task<IQueryable<Sucursal>> GetAll()
        {
            return await _sucursalRepo.GetAll();
        }

        public async Task<Sucursal> GetById(int id)
        {
            return await _sucursalRepo.GetById(id);
        }

        public async Task<Sucursal> GetByName(string name)
        {
            IQueryable<Sucursal> querySucursalSQL = await _sucursalRepo.GetAll();
            Sucursal sucursal = querySucursalSQL.Where(c => c.Nombre == name).FirstOrDefault();
            return sucursal;

        }

        public async Task<bool> Insert(Sucursal model)
        {
            return await _sucursalRepo.Insert(model);
        }

        public async Task<bool> Update(Sucursal model)
        {
            return await _sucursalRepo.Update(model);
        }
    }
}
