using CRM_SYSTEM.Data;
using CRM_SYSTEM.DTO.Users;
using CRM_SYSTEM.Models;

namespace CRM_SYSTEM.Repositories
{
    public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
    {
        public Users? GetByLogin(string login)
        {
            return dbContext.Users.FirstOrDefault(x => x.login == login);
        }
        public Users? GetById(int id)
        {
            return dbContext.Users.FirstOrDefault(x => x.id == id);
        }
        public void Add(Users user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
        public void Update()
        {
            dbContext.SaveChanges();
        }
        public void Delete(Users user)
        {
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
        }
    }
}
