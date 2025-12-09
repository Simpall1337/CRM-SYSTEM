using CRM_SYSTEM.Models;
using CRM_SYSTEM.DTO.Users;
namespace CRM_SYSTEM.Repositories
{
    public interface IUserRepository
    {
        public Users? GetByLogin(string login);
        public Users? GetById(int id);
        public Users? Add(Users request);
        public Users? Update(Users user);
    }
}
