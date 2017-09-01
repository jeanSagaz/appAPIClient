using appWebAPIClient.Domain.Models;
using System;
using System.Collections.Generic;

namespace appWebAPIClient.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>, IDisposable
    {
        User Get(string email);
        User Get(Guid id);
        List<User> Get(int skip, int take);
    }
}
