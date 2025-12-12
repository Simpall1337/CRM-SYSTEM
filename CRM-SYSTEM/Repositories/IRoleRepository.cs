using CRM_SYSTEM.DTO.Roles;
using CRM_SYSTEM.Models;

namespace CRM_SYSTEM.Repositories
{
    public interface IRoleRepository : IRepository<Roles>
    {
        public IEnumerable<Roles> GetAllRoles();
        public Roles? GetByName(string name);
    }
}
