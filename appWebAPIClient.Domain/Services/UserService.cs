using appWebAPIClient.Domain.Interfaces.Repositories;
using appWebAPIClient.Domain.Interfaces.Services;
using appWebAPIClient.Domain.Models;
using System;
using System.Collections.Generic;

namespace appWebAPIClient.Domain.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public User Get(string email)
        {
            return _userRepository.Get(email);
        }

        public User Get(Guid id)
        {
            return Get(id);
        }

        public List<User> Get(int skip, int take)
        {
            return _userRepository.Get(skip, take);
        }
    }
}
