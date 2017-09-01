using appWebAPIClient.Domain.Models;
using System.Collections.Generic;

namespace appWebAPIClient.Service.Services.Interfaces
{
    public interface IPhoneAppService : IAppServiceBase<Phone>
    {
        IEnumerable<Phone> GetAllbyClient(int clientId);
    }
}
