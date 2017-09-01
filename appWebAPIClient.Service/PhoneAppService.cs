using appWebAPIClient.Domain.Models;
using appWebAPIClient.Service.Services.Interfaces;
using appWebAPIClient.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace appWebAPIClient.Service.Services
{
    public class PhoneAppService : AppServiceBase<Phone>, IPhoneAppService
    {
        private readonly IPhoneService _phoneService;

        public PhoneAppService(IPhoneService phoneService) : base(phoneService)
        {
            _phoneService = phoneService;
        }

        public IEnumerable<Phone> GetAllbyClient(int clientId)
        {
            return _phoneService.GetAllbyClient(clientId);
        }
    }
}
