using appWebAPIClient.Domain.Interfaces.Repositories;
using appWebAPIClient.Domain.Interfaces.Services;
using appWebAPIClient.Domain.Services;
using appWebAPIClient.Infrastructure.Repository;
using appWebAPIClient.Service;
using appWebAPIClient.Service.Interfaces;
using appWebAPIClient.Service.Services;
using appWebAPIClient.Service.Services.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace appWebAPIClient.Application.SimpleInjector
{
    public static class SimpleInjectorWebApiInitializer
    {
        public static void Initialize(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            InitializeContainer(container);
            container.Verify();
        }

        private static void InitializeContainer(Container container)
        {
            //container.RegisterWebApiRequest<IClientAppService, ClientAppService>();
            //container.RegisterWebApiRequest<IClientService, ClientService>();
            //container.RegisterWebApiRequest<IClientRepository, ClientRepository>();

            container.Register<IClientAppService, ClientAppService>(Lifestyle.Scoped);
            container.Register<IClientService, ClientService>(Lifestyle.Scoped);
            container.Register<IClientRepository, ClientRepository>(Lifestyle.Scoped);

            //container.RegisterWebApiRequest<IPhoneAppService, PhoneAppService>();
            //container.RegisterWebApiRequest<IPhoneService, PhoneService>();
            //container.RegisterWebApiRequest<IPhoneRepository, PhoneRepository>();

            container.Register<IPhoneAppService, PhoneAppService>(Lifestyle.Scoped);
            container.Register<IPhoneService, PhoneService>(Lifestyle.Scoped);
            container.Register<IPhoneRepository, PhoneRepository>(Lifestyle.Scoped);

            container.Register<IUserAppService, UserAppService>(Lifestyle.Scoped);
            container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
        }
    }
}
