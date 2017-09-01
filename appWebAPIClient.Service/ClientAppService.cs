using System;
using appWebAPIClient.Domain.Interfaces.Services;
using appWebAPIClient.Domain.Models;
using appWebAPIClient.Service.Services.Interfaces;

namespace appWebAPIClient.Service.Services
{
    public class ClientAppService : AppServiceBase<Client>, IClientAppService
    {
        private readonly IClientService _clientService;

        public ClientAppService(IClientService clientService) 
            : base(clientService)
        {
            _clientService = clientService;
        }

        public Client GetDataByIdPhones(int id)
        {
            return _clientService.GetDataByIdPhones(id);
        }

        public void Register(Client client)
        {
            //faz a verificação se o cpf já esta salvo no banco de dados
            var hasClientCpf = _clientService.GetCpf(client.Cpf);
            //caso o cpf já estava salvo é gerado uma exceção
            if (hasClientCpf != null)
                throw new Exception("CPF já cadastrado.");

            //faz a verificação se é um cpf válido.
            bool boValidateCpf = client.ValidateCpf(client.Cpf);
            if (boValidateCpf)
            {
                client.Validate();
                //grava no banco de dados
                _clientService.Add(client);
            }
            else
                //throw new InvalidOperationException("CPF inválido.");
                throw new Exception("CPF inválido.");
        }

        public void UpdateClient(Client client)
        {
            client.Validate();
            _clientService.Update(client);
        }
    }
}
