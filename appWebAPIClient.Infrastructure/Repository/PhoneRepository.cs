using appWebAPIClient.Domain.Interfaces.Repositories;
using appWebAPIClient.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace appWebAPIClient.Infrastructure.Repository
{
    public class PhoneRepository : RepositoryBase<Phone>, IPhoneRepository
    {
        public IEnumerable<Phone> GetAllbyClient(int clientId)
        {
            return GetData(p => p.ClientId == clientId, "Client").ToList();
        }
    }
}
