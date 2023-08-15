using ProyectoSucursal.DAL.Repositories;
using ProyectoSucursal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSucursal.BLL.Service
{
    public class TecnicoService : ITecnicoService
    {
        private readonly IGenericRepository<Tecnico> _tecnicoRepo;
        public TecnicoService(IGenericRepository<Tecnico> tecnicoRepo)
        {
            _tecnicoRepo = tecnicoRepo;
        }
        public async Task<bool> Delete(int id)
        {
            return await _tecnicoRepo.Delete(id);
        }

        public async Task<IQueryable<Tecnico>> GetAll()
        {
            return await _tecnicoRepo.GetAll();
        }

        public async Task<Tecnico> GetById(int id)
        {
            return await _tecnicoRepo.GetById(id);
        }

        public async Task<bool> Insert(Tecnico model)
        {
            return await _tecnicoRepo.Insert(model);
        }

        public async Task<bool> Update(Tecnico model)
        {
            return await _tecnicoRepo.Update(model);
        }

        public async Task<Tecnico> GetByLast()
        {
            IQueryable<Tecnico> queryTecnicoSQL = await _tecnicoRepo.GetAll();
            Tecnico tecnico = queryTecnicoSQL.OrderByDescending(i => i.Id).FirstOrDefault();

            return tecnico;
        }

        public async Task<Tecnico> GetByCodigo(string codigo)
        {
            IQueryable<Tecnico> queryTecnicoSQL = await _tecnicoRepo.GetAll();

            Tecnico tecnico = queryTecnicoSQL.Where(i => i.Codigo == codigo).First();

            return tecnico; ;
        }
    }
}
