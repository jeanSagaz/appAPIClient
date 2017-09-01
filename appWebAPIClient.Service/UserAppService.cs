using appWebAPIClient.Common.Resources;
using appWebAPIClient.Common.Validation;
using appWebAPIClient.Domain.Interfaces.Services;
using appWebAPIClient.Domain.Models;
using appWebAPIClient.Service.Interfaces;
using appWebAPIClient.Service.Services;
using System;
using System.Collections.Generic;

namespace appWebAPIClient.Service
{
    public class UserAppService : AppServiceBase<User>, IUserAppService
    {
        private readonly IUserService _userService;
        public UserAppService(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        public User Authenticate(string email, string password)
        {
            var user = GetByEmail(email);

            if (user.Password != PasswordAssertionConcern.Encrypt(password))
                throw new Exception(Errors.InvalidCredentials);

            return user;
        }

        public void ChangeInformation(string email, string name)
        {
            var user = GetByEmail(email);

            user.ChangeName(name);
            user.Validate();

            _userService.Update(user);
        }

        public void ChangePassword(string email, string password, string newPassword, string confirmNewPassword)
        {
            var user = Authenticate(email, password);

            user.SetPassword(newPassword, confirmNewPassword);
            user.Validate();

            _userService.Update(user);
        }

        public void Register(string name, string email, string password, string confirmPassword)
        {
            var hasUser = _userService.Get(email);
            if (hasUser != null)
                throw new Exception(Errors.DuplicateEmail);

            var user = new User(name, email);
            user.SetPassword(password, confirmPassword);
            user.Validate();

            _userService.Add(user);
        }

        public User GetByEmail(string email)
        {
            var user = _userService.Get(email);
            if (user == null)
                throw new Exception(Errors.UserNotFound);

            return user;
        }

        public string ResetPassword(string email)
        {
            var user = GetByEmail(email);
            var password = user.ResetPassword();
            user.Validate();

            _userService.Update(user);
            return password;
        }

        public List<User> GetByRange(int skip, int take)
        {
            return _userService.Get(skip, take);
        }
    }
}
