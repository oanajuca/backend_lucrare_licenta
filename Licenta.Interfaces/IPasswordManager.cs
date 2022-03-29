
using Licenta.Models.Dto;

namespace Licenta.Interfaces
{
    public interface IPasswordManager
    {
        MessageDto ChangePassword(string username, string oldPassword, string newPassword);
    }
}
