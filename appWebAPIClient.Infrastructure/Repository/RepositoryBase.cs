using appWebAPIClient.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using appWebAPIClient.Domain.Interfaces.Repositories;

namespace appWebAPIClient.Infrastructure.Repository
{
    public class RepositoryBase<Entity> : IDisposable, IRepositoryBase<Entity> where Entity : class
    {
        protected AppDataContext Db = new AppDataContext();

        public IEnumerable<Entity> GetAll()
        {
            return Db.Set<Entity>().ToList();
        }

        public Entity GetById(int id)
        {
            return Db.Set<Entity>().Find(id);
        }

        public IQueryable<Entity> GetData(Expression<Func<Entity, bool>> predicate, params string[] tables)
        {
            var query = Db.Set<Entity>().AsQueryable();

            if(tables != null)
            {
                foreach (string table in tables)
                    query = query.Include(table);
            }                

            query = (predicate != null) ? query.Where(predicate) : query;

            return query;
        }

        public void Add(Entity obj)
        {
            Db.Set<Entity>().Add(obj);
            Db.SaveChanges();
        }

        public void Update(Entity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(Entity obj)
        {
            Db.Set<Entity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
