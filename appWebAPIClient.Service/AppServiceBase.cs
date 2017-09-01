using appWebAPIClient.Domain.Interfaces.Services;
using appWebAPIClient.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace appWebAPIClient.Service.Services
{
    public class AppServiceBase<Entity> : IDisposable, IAppServiceBase<Entity> where Entity : class
    {
        private readonly IServiceBase<Entity> _serviceBase;
        
        public AppServiceBase(IServiceBase<Entity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(Entity obj)
        {
            _serviceBase.Add(obj);
        }

        public Entity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public IEnumerable<Entity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Update(Entity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Remove(Entity obj)
        {
            _serviceBase.Remove(obj);
        }

        public IQueryable<Entity> GetData(Expression<Func<Entity, bool>> predicate, params string[] tables)
        {
            return _serviceBase.GetData(predicate, tables);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }        
    }
}
