using appWebAPIClient.Domain.Models;
using System;

namespace appWebAPIClient.Domain.Interfaces.Repositories
{
    public interface IClientRepository : IRepositoryBase<Client>, IDisposable
    {
        Client GetCpf(string cpf);
        Client GetDataByIdPhones(int id);
    }
}
