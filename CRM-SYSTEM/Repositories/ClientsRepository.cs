using CRM_SYSTEM.CustomExceptions;
using CRM_SYSTEM.Data;
using CRM_SYSTEM.DTO.Clients;
using CRM_SYSTEM.Models;
using System.Security.Cryptography;

namespace CRM_SYSTEM.Repositories
{
    public class ClientsRepository(ApplicationDbContext dbContext) : IClientsRepository
    {
        public IEnumerable<Clients> GetAllClients()
        {
            return dbContext.Clients.ToList();
        }
        public Clients GetById(int id)
        {
            return dbContext.Clients.FirstOrDefault(x => x.id == id);
        }
        public bool GetAnyPhone(string phone)
        {
            return dbContext.Clients.Any(x => x.phone == phone);
        }
        public bool GetAnyEmail(string email) 
        { 
            return dbContext.Clients.Any(x => x.email == email); 
        }
        public void Add(Clients clients)
        {
            dbContext.Clients.Add(clients);
            dbContext.SaveChanges();
        }
        public void Update()
        {
            dbContext.SaveChanges();
        }
        public void Delete(Clients client)
        {
            dbContext.Clients.Remove(client);
            dbContext.SaveChanges();
        }
    }
}
