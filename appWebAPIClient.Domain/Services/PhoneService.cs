using appWebAPIClient.Domain.Interfaces.Repositories;
using appWebAPIClient.Domain.Interfaces.Services;
using appWebAPIClient.Domain.Models;
using System.Collections.Generic;

namespace appWebAPIClient.Domain.Services
{
    public class PhoneService : ServiceBase<Phone>, IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
            : base(phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public IEnumerable<Phone> GetAllbyClient(int clientId)
        {
            return _phoneRepository.GetAllbyClient(clientId);
        }
    }
}
