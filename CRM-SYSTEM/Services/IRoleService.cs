using CRM_SYSTEM.DTO.Roles;
using CRM_SYSTEM.Models;

namespace CRM_SYSTEM.Services
{
    public interface IRoleService
    {
        public IEnumerable<Roles> GetAllRoles();
        public ResponseUpdate UpdateRole(RequestUpdate role);
        public ResponseCreate CreateRole(RequestCreate role);
        public void DeleteRole(int id);
    }
}
