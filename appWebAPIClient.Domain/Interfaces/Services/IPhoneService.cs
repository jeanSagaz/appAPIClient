using appWebAPIClient.Domain.Models;
using System;
using System.Collections.Generic;

namespace appWebAPIClient.Domain.Interfaces.Services
{
    public interface IPhoneService : IServiceBase<Phone>, IDisposable
    {
        IEnumerable<Phone> GetAllbyClient(int clientId);
    }
}
