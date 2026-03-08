using CRM_SYSTEM.DTO.Users;
using CRM_SYSTEM.Models;
using CRM_SYSTEM.Projections;
namespace CRM_SYSTEM.Repositories.Interfaces
{
    public interface IUserRepository: IRepository<Users>
    {
        Users? GetByLogin(string login);
        UserTokenPayload? GetUserDataForToken(string login);
    }
}
