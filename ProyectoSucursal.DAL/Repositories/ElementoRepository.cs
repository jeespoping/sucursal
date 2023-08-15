using ProyectoSucursal.DAL.DataContext;
using ProyectoSucursal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSucursal.DAL.Repositories
{
    public class ElementoRepository : IGenericRepository<Elemento>
    {
        private readonly SucursalContext _dbcontext;

        public ElementoRepository(SucursalContext context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Delete(int id)
        {
            Elemento model = _dbcontext.Elementos.First(c => c.Codigo == id);
            _dbcontext.Elementos.Remove(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Elemento>> GetAll()
        {
            IQueryable<Elemento> queryElementoSQL = _dbcontext.Elementos;
            return queryElementoSQL;
        }

        public async Task<Elemento> GetById(int id)
        {
            return await _dbcontext.Elementos.FindAsync(id);
        }

        public async Task<bool> Insert(Elemento model)
        {
            _dbcontext.Elementos.Add(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Elemento model)
        {
            _dbcontext.Elementos.Update(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
