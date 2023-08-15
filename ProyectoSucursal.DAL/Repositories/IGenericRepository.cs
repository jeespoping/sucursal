using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSucursal.DAL.Repositories
{
    public interface IGenericRepository<TEntityModel> where TEntityModel:class
    {
        Task<bool> Insert(TEntityModel model);

        Task<bool> Update(TEntityModel model);

        Task<bool> Delete(int id);

        Task<TEntityModel> GetById(int id);

        Task<IQueryable<TEntityModel>> GetAll();
    }
}
