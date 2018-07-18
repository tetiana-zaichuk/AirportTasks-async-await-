using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<List<TEntity>> GetAsync(int? filter = null);

        Task CreateAsync(TEntity entity, string createdBy = null);

        Task CreateListAsync(List<TEntity> listEntity, string createdBy = null);

        void Update(TEntity entity, string modifiedBy = null);

        void Delete(int? filter = null);
    }
}
