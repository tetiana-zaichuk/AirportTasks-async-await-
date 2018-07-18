using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly AirportContext Context;

        public Repository(AirportContext context)
        {
            Context = context;
        }

        public virtual async Task<List<TEntity>> GetAsync(int? filter = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(e => e.Id == filter);
            }

            return await query.ToListAsync();
        }

        public virtual async Task CreateAsync(TEntity entity, string createdBy = null)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public virtual async Task CreateListAsync(List<TEntity> listEntity, string createdBy = null)
        {
            await Context.Set<TEntity>().AddRangeAsync(listEntity);
        }

        public virtual void Update(TEntity entity, string modifiedBy = null)
        {
            TEntity oldEntity = Context.Set<TEntity>().Find(entity.Id);
                Context.Entry(oldEntity).State = EntityState.Detached;
            //Context.Set<TEntity>().Update(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int? filter = null)
        {
            List<TEntity> query = Context.Set<TEntity>().ToList();

            if (filter != null)
            {
                Delete(query.Find(e => e.Id == filter));
            }
            else
            {
                Context.Set<TEntity>().RemoveRange(query);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            var dbSet = Context.Set<TEntity>();
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
    }
}
