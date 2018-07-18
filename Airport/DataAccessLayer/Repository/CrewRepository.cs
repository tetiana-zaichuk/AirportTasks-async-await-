using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class CrewRepository : IRepository<Crew>
    {
        protected readonly AirportContext Context;

        public CrewRepository(AirportContext context)
        {
            Context = context;
        }

        public virtual List<Crew> Get(int? filter = null)
        {
            IQueryable<Crew> query = Context.Set<Crew>().Include(c=>c.Stewardesses).Include(c=>c.Pilot);

            if (filter != null)
            {
                query = query.Where(e => e.Id == filter);
            }

            return query.ToList();
        }

        public virtual void Create(Crew entity, string createdBy = null)
        {
            Context.Set<Crew>().Add(entity);
        }

        public virtual void Update(Crew entity, string modifiedBy = null)
        {
            Crew oldEntity = Context.Set<Crew>().Find(entity.Id);
            Context.Entry(oldEntity).State = EntityState.Detached;
            //Context.Set<TEntity>().Update(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int? filter = null)
        {
            List<Crew> query = Context.Set<Crew>().ToList();

            if (filter != null)
            {
                Delete(query.Find(e => e.Id == filter));
            }
            else
            {
                Context.Set<Crew>().RemoveRange(query);
            }
        }

        public virtual void Delete(Crew entity)
        {
            var dbSet = Context.Set<Crew>();
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
    }
}
