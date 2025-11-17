using CRM_SYSTEM.Models;

namespace CRM_SYSTEM.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUser(); 
    }
}
