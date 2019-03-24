using appWebAPIClient.Domain.Models;

namespace appWebAPIClient.Service.Services.Interfaces
{
    public interface IClientAppService : IAppServiceBase<Client>
    {
        #region Service

        void Register(Client client);
        void UpdateClient(Client client);

        #endregion

        #region Repository

        Client GetDataByIdPhones(int id);

        #endregion
    }
}
