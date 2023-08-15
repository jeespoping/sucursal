using ProyectoSucursal.DAL.DataContext;
using ProyectoSucursal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSucursal.DAL.Repositories
{
    public class SucursalRepository : IGenericRepository<Sucursal>
    {
        private readonly SucursalContext _dbcontext;
        public SucursalRepository(SucursalContext context)
        {
            _dbcontext = context;
        }
        public async Task<bool> Delete(int id)
        {
            Sucursal model = _dbcontext.Sucursals.First(c => c.Codigo == id);
            _dbcontext.Sucursals.Remove(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Sucursal>> GetAll()
        {
            IQueryable<Sucursal> querySucursalSQL = _dbcontext.Sucursals;
            return querySucursalSQL;
        }

        public async Task<Sucursal> GetById(int id)
        {
            return await _dbcontext.Sucursals.FindAsync(id);
        }

        public async Task<bool> Insert(Sucursal model)
        {
            _dbcontext.Sucursals.Add(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Sucursal model)
        {
            _dbcontext.Sucursals.Update(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }   
    }
}
