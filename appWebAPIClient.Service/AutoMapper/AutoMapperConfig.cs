using appWebAPIClient.Domain.Models;
using appWebAPIClient.Service.ViewModels;
using AutoMapper;

namespace appWebAPIClient.Service.AutoMapper
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
            });
        }
    }
}
