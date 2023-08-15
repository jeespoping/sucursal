using ProyectoSucursal.DAL.DataContext;
using ProyectoSucursal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSucursal.DAL.Repositories
{
    public class AsignacionRepository : IGenericRepository<Asignacion>
    {
        private readonly SucursalContext _dbcontext;

        public AsignacionRepository(SucursalContext context)
        {
            _dbcontext = context;
        }
        public async Task<bool> Delete(int id)
        {
            Asignacion model = _dbcontext.Asignacions.First(c => c.Id == id);
            _dbcontext.Asignacions.Remove(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Asignacion>> GetAll()
        {
            IQueryable<Asignacion> queryAsignacionSQL = _dbcontext.Asignacions;
            return queryAsignacionSQL;
        }

        public async Task<Asignacion> GetById(int id)
        {
            return await _dbcontext.Asignacions.FindAsync(id);
        }

        public async Task<bool> Insert(Asignacion model)
        {
            _dbcontext.Asignacions.Add(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Asignacion model)
        {
            _dbcontext.Asignacions.Update(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
