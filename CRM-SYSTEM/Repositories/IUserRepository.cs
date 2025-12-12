using CRM_SYSTEM.Models;
using CRM_SYSTEM.DTO.Users;
namespace CRM_SYSTEM.Repositories
{
    public interface IUserRepository: IRepository<Users>
    {
        Users? GetByLogin(string login);
    }
}
