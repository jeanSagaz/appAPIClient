using appWebAPIClient.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using appWebAPIClient.Domain.Interfaces.Repositories;

namespace appWebAPIClient.Domain.Services
{
    public class ServiceBase<Entity> : IDisposable, IServiceBase<Entity> where Entity : class
    {
        private readonly IRepositoryBase<Entity> _repository;

        public ServiceBase(IRepositoryBase<Entity> repository)
        {
            _repository = repository;
        }

        public void Add(Entity obj)
        {
            _repository.Add(obj);
        }        

        public IEnumerable<Entity> GetAll()
        {
            return _repository.GetAll();
        }

        public Entity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IQueryable<Entity> GetData(Expression<Func<Entity, bool>> predicate, params string[] tables)
        {
            return _repository.GetData(predicate, tables);                
        }        

        public void Update(Entity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(Entity obj)
        {
            _repository.Remove(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
