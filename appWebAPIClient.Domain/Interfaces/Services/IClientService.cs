using appWebAPIClient.Domain.Models;
using System;

namespace appWebAPIClient.Domain.Interfaces.Services
{
    public interface IClientService : IServiceBase<Client>, IDisposable
    {
        Client GetCpf(string cpf);
        Client GetDataByIdPhones(int id);
    }
}
