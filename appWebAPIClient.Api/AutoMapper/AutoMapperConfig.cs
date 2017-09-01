using appWebAPIClient.Api.Models;
using appWebAPIClient.Domain.Models;
using AutoMapper;

namespace appWebAPIClient.Api.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
                {
                    x.CreateMap<Client, ClientViewModel>();
                    x.CreateMap<Phone, PhoneViewModel>();

                    x.CreateMap<ClientViewModel, Client>();
                    x.CreateMap<PhoneViewModel, Phone>();
                }
            );
        }
    }
}