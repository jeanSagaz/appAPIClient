using appWebAPIClient.Domain.Interfaces.Repositories;
using appWebAPIClient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace appWebAPIClient.Infrastructure.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public User Get(string email)
        {
            return Db.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public User Get(Guid id)
        {
            return Db.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<User> Get(int skip, int take)
        {
            return Db.Users.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
        }
    }
}
