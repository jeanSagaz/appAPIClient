using appWebAPIClient.Domain.Interfaces.Repositories;
using appWebAPIClient.Domain.Interfaces.Services;
using appWebAPIClient.Domain.Services;
using appWebAPIClient.Infrastructure.Repository;
using appWebAPIClient.Service;
using appWebAPIClient.Service.Interfaces;
using appWebAPIClient.Service.Services;
using appWebAPIClient.Service.Services.Interfaces;
using Microsoft.Practices.Unity;

namespace appWebAPIClient.Application
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            //container.RegisterType(typeof(IAppServiceBase<>), typeof(IAppServiceBase<>));

            container.RegisterType<IClientAppService, ClientAppService>(new HierarchicalLifetimeManager());
            container.RegisterType<IClientService, ClientService>(new HierarchicalLifetimeManager());
            container.RegisterType<IClientRepository, ClientRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IPhoneAppService, PhoneAppService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPhoneService, PhoneService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPhoneRepository, PhoneRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IUserAppService, UserAppService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());

            //container.RegisterType(typeof(IServiceBase<>), typeof(ServiceBase<>));
            //container.RegisterType(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            //container.RegisterType<Client, Client>(new HierarchicalLifetimeManager());
            //container.RegisterType<Phone, Phone>(new HierarchicalLifetimeManager());
        }
    }
}