using ProyectoSucursal.DAL.DataContext;
using ProyectoSucursal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSucursal.DAL.Repositories
{
    public class TecnicoRepository : IGenericRepository<Tecnico>
    {
        private readonly SucursalContext _dbcontext;

        public TecnicoRepository(SucursalContext context)
        {
            _dbcontext = context;
        }
        public async Task<bool> Delete(int id)
        {
            Tecnico model = _dbcontext.Tecnicos.First(c => c.Id == id);
            _dbcontext.Tecnicos.Remove(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Tecnico>> GetAll()
        {
            IQueryable<Tecnico> queryTecnicoSQL = _dbcontext.Tecnicos;
            return queryTecnicoSQL;
        }

        public async Task<Tecnico> GetById(int id)
        {
            return await _dbcontext.Tecnicos.FindAsync(id);
        }

        public async Task<bool> Insert(Tecnico model)
        {
            _dbcontext.Tecnicos.Add(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Tecnico model)
        {
            _dbcontext.Tecnicos.Update(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
