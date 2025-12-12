using CRM_SYSTEM.CustomExceptions;
using CRM_SYSTEM.Data;
using CRM_SYSTEM.DTO.Roles;
using CRM_SYSTEM.Models;
using System.Linq;

namespace CRM_SYSTEM.Repositories
{
    public class RoleRepository(ApplicationDbContext dbContext) : IRoleRepository
    {
        public Roles? GetById(int id)
        {
            return dbContext.Roles.FirstOrDefault(x => x.id == id);
        }
        public IEnumerable<Roles> GetAllRoles()
        {
            return dbContext.Roles.ToList();
        }
        public Roles? GetByName(string name)
        {
            return dbContext.Roles.FirstOrDefault(x => x.name == name);
        }

        public void Add(Roles role)
        {
            dbContext.Roles.Add(role);
            dbContext.SaveChanges();
        }
        public void Update()
        {
            dbContext.SaveChanges();
        }
        public void Delete(Roles role)
        {
            dbContext.Roles.Remove(role);
            dbContext.SaveChanges();
        }


    }
}
