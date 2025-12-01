using CRM_SYSTEM.Data;
using CRM_SYSTEM.DTO.Users;
using CRM_SYSTEM.Models;

namespace CRM_SYSTEM.Repositories
{
    public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
    {
        public User? GetByLogin(string login)
        {
            return dbContext.Users.FirstOrDefault(x => x.login == login);
        }
        public User? GetById(int id)
        {
            return dbContext.Users.FirstOrDefault(x => x.id == id);
        }
        public User? Add(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }
        public User? Update(User user)
        {
            dbContext.Users.Update(user);
            dbContext.SaveChanges();
            return user;
        }
    }
}
