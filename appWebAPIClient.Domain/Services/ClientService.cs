using appWebAPIClient.Domain.Interfaces.Services;
using appWebAPIClient.Domain.Models;
using System;
using appWebAPIClient.Domain.Interfaces.Repositories;

namespace appWebAPIClient.Domain.Services
{
    public class ClientService : ServiceBase<Client>, IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository) : base(clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client GetCpf(string cpf)
        {
            return _clientRepository.GetCpf(cpf);
        }

        public Client GetDataByIdPhones(int id)
        {
            return _clientRepository.GetDataByIdPhones(id);
        }
    }
}
