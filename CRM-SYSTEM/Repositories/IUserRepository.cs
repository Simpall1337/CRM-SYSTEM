using CRM_SYSTEM.Models;
using CRM_SYSTEM.DTO.Users;
namespace CRM_SYSTEM.Repositories
{
    public interface IUserRepository
    {
        public User? GetByLogin(string login);
        public User? Add(User request);
    }
}
