using appWebAPIClient.Domain.Interfaces.Repositories;
using appWebAPIClient.Domain.Models;
using System.Linq;
using appWebAPIClient.Infrastructure.Context;

namespace appWebAPIClient.Infrastructure.Repository
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {      
        public Client GetCpf(string cpf)
        {
            return Db.Clients.Where(c => c.Cpf == cpf).FirstOrDefault();
        }

        public Client GetDataByIdPhones(int id)
        {
            return GetData(c => c.ClientId == id, "Phones").FirstOrDefault();
        }
    }
}
