using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using ProyectoSucursal.DAL.Repositories;
using ProyectoSucursal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProyectoSucursal.BLL.Service
{
    public class AsignacionService : IAsignacionService
    {
        private readonly IGenericRepository<Asignacion> _asignacionrepo;
        public AsignacionService(IGenericRepository<Asignacion> asignacionrepo)
        {
            _asignacionrepo = asignacionrepo;
        }
        public async Task<bool> Delete(int id)
        {
            return await _asignacionrepo.Delete(id);
        }

        public async Task<IQueryable<Asignacion>> GetAll()
        {
            return await _asignacionrepo.GetAll();
        }

        public async Task<Asignacion> GetById(int id)
        {
            return await _asignacionrepo.GetById(id);
        }

        public async Task<bool> Insert(Asignacion model)
        {
            return await _asignacionrepo.Insert(model);
        }

        public async Task<bool> Update(Asignacion model)
        {
            return await _asignacionrepo.Update(model);
        }

        public async Task<bool> DeleteByTecnico(int id)
        {
            IQueryable<Asignacion> queryContactoSQL = await _asignacionrepo.GetAll();
            IQueryable<Asignacion> asignaciones = queryContactoSQL.Where(i => i.IdTecnico == id);

            foreach (var registro in asignaciones)
            {
                await _asignacionrepo.Delete(registro.Id);
            }

            return true;
        }

 

        public async Task<IQueryable<Asignacion>> GetByTecnico(int id)
        {
            IQueryable<Asignacion> queryContactoSQL = await _asignacionrepo.GetAll();
            IQueryable<Asignacion> asignaciones = queryContactoSQL.Where(i => i.IdTecnico == id);

            return asignaciones;
        }
    }
}
