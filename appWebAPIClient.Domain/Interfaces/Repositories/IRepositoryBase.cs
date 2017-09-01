using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace appWebAPIClient.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<Entity> where Entity : class
    {
        void Add(Entity obj);

        Entity GetById(int id);

        IEnumerable<Entity> GetAll();

        void Update(Entity obj);

        void Remove(Entity obj);

        IQueryable<Entity> GetData(Expression<Func<Entity, bool>> predicate, params string[] tables);

        void Dispose();
    }
}
