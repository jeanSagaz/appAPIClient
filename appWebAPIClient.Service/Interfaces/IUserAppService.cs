using appWebAPIClient.Domain.Models;
using appWebAPIClient.Service.Services.Interfaces;
using System.Collections.Generic;

namespace appWebAPIClient.Service.Interfaces
{
    public interface IUserAppService : IAppServiceBase<User>
    {
        User Authenticate(string email, string password);
        User GetByEmail(string email);
        void Register(string name, string email, string password, string confirmPassword);
        void ChangeInformation(string email, string name);
        void ChangePassword(string email, string password, string newPassword, string confirmNewPassword);
        string ResetPassword(string email);
        List<User> GetByRange(int skip, int take);
    }
}
