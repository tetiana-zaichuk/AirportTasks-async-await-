using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class AircraftRepository : IRepository<Aircraft>
    {
        protected readonly AirportContext Context;

        public AircraftRepository(AirportContext context)
        {
            Context = context;
        }

        public virtual Task<List<Aircraft>> GetAsync(int? filter = null)
        {
            IQueryable<Aircraft> query = Context.Set<Aircraft>().Include(c => c.AircraftType);

            if (filter != null)
            {
                query = query.Where(e => e.Id == filter);
            }

            return query.ToListAsync();
        }

        public virtual async Task CreateAsync(Aircraft entity, string createdBy = null)
        {
            await Context.Set<Aircraft>().AddAsync(entity);
        }

        public virtual async Task CreateListAsync(List<Aircraft> listEntity, string createdBy = null)
        {
            await Context.Set<Aircraft>().AddRangeAsync(listEntity);
        }

        public virtual void Update(Aircraft entity, string modifiedBy = null)
        {
            Aircraft oldEntity = Context.Set<Aircraft>().Find(entity.Id);
            Context.Entry(oldEntity).State = EntityState.Detached;
            //Context.Set<TEntity>().Update(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int? filter = null)
        {
            var query = Context.Set<Aircraft>().ToList();

            if (filter != null)
            {
                Delete(query.Find(e => e.Id == filter));
            }
            else
            {
                Context.Set<Aircraft>().RemoveRange(query);
            }
        }

        public virtual void Delete(Aircraft entity)
        {
            var dbSet = Context.Set<Aircraft>();
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
    }
}
