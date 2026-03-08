using CRM_SYSTEM.Data;
using CRM_SYSTEM.DTO.Users;
using CRM_SYSTEM.Models;
using CRM_SYSTEM.Projections;
using CRM_SYSTEM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRM_SYSTEM.Repositories
{
    public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
    {
        public Users? GetByLogin(string login)
        {
            return dbContext.Users.FirstOrDefault(x => x.login == login);
        }
        public UserTokenPayload? GetUserDataForToken(string login)
        {
            return dbContext.Users.AsNoTracking()
                                  .Where(x => x.login == login)
                                  .LeftJoin(dbContext.Roles, user => user.role_id
                                           , role => role.role_id,
                                           (user, role) => new UserTokenPayload
                                           {
                                               id = user.id,
                                               email = user.email,
                                               role = role.name
                                           })
                                  .FirstOrDefault();
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
        public void Update(Users user)
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
