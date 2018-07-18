using System.Collections.Generic;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        List<TEntity> Get(int? filter = null);

        void Create(TEntity entity, string createdBy = null);

        void Update(TEntity entity, string modifiedBy = null);

        void Delete(int? filter = null);
    }
}
