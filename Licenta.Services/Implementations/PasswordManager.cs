using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Licenta.Infrastructure.Wrappers;
using Licenta.Interfaces;
using Licenta.Models.Dto;

namespace Licenta.Services.Implementations
{
    public class PasswordManager :IPasswordManager
    {
        private IRepository _repository;
        public PasswordManager(IRepository repository)
        {
            _repository = repository;
        }

        public MessageDto ChangePassword(string username, string oldPassword, string newPassword)
        {
            var user = _repository.GetUserObject(username, oldPassword);

            if (user != null)
            {
                if (user.Password == newPassword)
                {
                    return new MessageDto { Category = Constants.Warn, Description = "New password is similar to the old password used." };
                }
                user.Password = newPassword;
                _repository.UpdateUserPassword(user);
            }

            return new MessageDto { Category = Constants.Info, Description = "Password has been updated." };
        }
    }
}
