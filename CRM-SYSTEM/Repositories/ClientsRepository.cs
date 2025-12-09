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
        public ClientsCreateResponse CreateClients(Clients clients)
        {
            if (dbContext.Clients.Any(x => x.phone == clients.phone || x.email == clients.email))
            {
                throw new ClientAlreadyExistsException("Client with the same phone or email already exists.");
            }

            dbContext.Clients.Add(clients);
            dbContext.SaveChanges();

            var response = new ClientsCreateResponse
            {
                id = clients.id,
                firstName = clients.first_name,
                lastName = clients.last_name,
                email = clients.email,
                phone = clients.phone,
                address = clients.address,
                created_at = clients.created_at
            };

            return response;
        }
        public ClientsUpdateResponse UpdateClient(Clients client)
        {
            var existingClient = dbContext.Clients.FirstOrDefault(x => x.id == client.id);
            if (existingClient == null)
            {
                throw new ClientNotFoundException();
            }

            existingClient.first_name = client.first_name;
            existingClient.last_name = client.last_name;
            existingClient.email = client.email;
            existingClient.address = client.address;
            existingClient.phone = client.phone;

            dbContext.SaveChanges();

            return new ClientsUpdateResponse
            {
                id = client.id,
                first_name = client.first_name,
                last_name = client.last_name,
                email = client.email,
                address = client.address,
                phone = client.phone
            };
        }
        public void DeleteClient(int id)
        {
            var client = dbContext.Clients.FirstOrDefault(x => x.id == id);
            if (client == null)
            {
                throw new ClientNotFoundException();
            }

            dbContext.Clients.Remove(client);
            dbContext.SaveChanges();
        }
    }
}
