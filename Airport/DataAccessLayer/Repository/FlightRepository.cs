using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class FlightRepository : IRepository<Flight>
    {
        protected readonly AirportContext Context;

        public FlightRepository(AirportContext context)
        {
            Context = context;
        }
        
        public virtual async Task<List<Flight>> GetAsync(int? filter = null)
        {
            IQueryable<Flight> query = Context.Set<Flight>().Include(c => c.Tickets);

            if (filter != null)
            {
                query = query.Where(e => e.Id == filter);
            }

            return await query.ToListAsync();
        }

        public virtual async Task CreateAsync(Flight entity, string createdBy = null)
        {
            await Context.Set<Flight>().AddAsync(entity);
        }

        public virtual async Task CreateListAsync(List<Flight> listEntity, string createdBy = null)
        {
            await Context.Set<Flight>().AddRangeAsync(listEntity);
        }

        public virtual void Update(Flight entity, string modifiedBy = null)
        {
            Flight oldEntity = Context.Set<Flight>().Find(entity.Id);
            Context.Entry(oldEntity).State = EntityState.Detached;
            //Context.Set<TEntity>().Update(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int? filter = null)
        {
            List<Flight> query = Context.Set<Flight>().ToList();

            if (filter != null)
            {
                Delete(query.Find(e => e.Id == filter));
            }
            else
            {
                Context.Set<Flight>().RemoveRange(query);
            }
        }

        public virtual void Delete(Flight entity)
        {
            var dbSet = Context.Set<Flight>();
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
    }
}
