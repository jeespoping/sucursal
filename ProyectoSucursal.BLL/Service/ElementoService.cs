using ProyectoSucursal.DAL.Repositories;
using ProyectoSucursal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSucursal.BLL.Service
{
    public class ElementoService : IElementoService
    {
        private readonly IGenericRepository<Elemento> _elementorepo;
        public ElementoService(IGenericRepository<Elemento> elementorepo)
        {
            _elementorepo = elementorepo;
        }
        public async Task<bool> Delete(int id)
        {
            return await _elementorepo.Delete(id);
        }

        public async Task<IQueryable<Elemento>> GetAll()
        {
            return await _elementorepo.GetAll();
        }

        public async Task<Elemento> GetById(int id)
        {
            return await _elementorepo.GetById(id);
        }

        public async Task<bool> Insert(Elemento model)
        {
            return await _elementorepo.Insert(model);
        }

        public async Task<bool> Update(Elemento model)
        {
            return await _elementorepo.Update(model);
        }
    }
}
