using appWebAPIClient.Domain.Models;
using System;
using System.Collections.Generic;

namespace appWebAPIClient.Domain.Interfaces.Repositories
{
    public interface IPhoneRepository : IRepositoryBase<Phone>, IDisposable
    {
        IEnumerable<Phone> GetAllbyClient(int clientId);
    }
}
