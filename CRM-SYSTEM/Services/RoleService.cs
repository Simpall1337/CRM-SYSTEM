using CRM_SYSTEM.CustomExceptions;
using CRM_SYSTEM.DTO.Roles;
using CRM_SYSTEM.Models;
using CRM_SYSTEM.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRM_SYSTEM.Services
{
    public class RoleService(IRoleRepository roleRepository) : IRoleService
    {
        public IEnumerable<Roles> GetAllRoles()
        {
            return roleRepository.GetAllRoles();
        }
        public ResponseCreate CreateRole(RequestCreate request)
        {
            var existingRole = roleRepository.GetByName(request.name);
            if (existingRole != null)
            {
                throw new AlreadyExistsRoleException();
            }

            var role = new Roles
            {
                name = request.name,
                description = request.description
            };

            roleRepository.Add(role);

            return new ResponseCreate
            {
                id = role.id,
                name = role.name,
                description = role.description
            };
        }
        public ResponseUpdate UpdateRole(RequestUpdate request)
        {
            var existingRole = roleRepository.GetById(request.id);
            if (existingRole == null)
            {
                throw new NotFoundRoleException();
            }

            if (!string.IsNullOrEmpty(request.name))
                existingRole.name = request.name;

            if (!string.IsNullOrEmpty(request.description))
                existingRole.description = request.description;

            roleRepository.Update();

            return new ResponseUpdate
            {
                id = existingRole.id,
                name = existingRole.name,
                description = existingRole.description
            };
        }
        public void DeleteRole(int id)
        {
            var role = roleRepository.GetById(id);

            if (role == null) throw new NotFoundRoleException();

            roleRepository.Delete(role);
        }
    }
}
