using CRM_SYSTEM.CustomExceptions;
using CRM_SYSTEM.DTO.Clients;
using CRM_SYSTEM.Models;
using CRM_SYSTEM.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRM_SYSTEM.Services
{
    public class ClientsService(IClientsRepository clientsRepository) : IClientsService
    {
        public IEnumerable<Clients> GetAllClients()
        {
            return clientsRepository.GetAllClients();
        }
        public ClientsCreateResponse CreateClients(ClientsCreateRequest request)
        {
            var existsPhone = clientsRepository.GetAnyPhone(request.phone);
            var existsEmail = clientsRepository.GetAnyEmail(request.email);

            if (existsPhone)
                throw new ClientAlreadyExistsException("Phone already exists");

            if (existsEmail)
                throw new ClientAlreadyExistsException("Email already exists");

            var client = new Clients
            {
                first_name = request.firstName,
                last_name = request.lastName,
                email = request.email,
                phone = request.phone,
                address = request.address,
                created_at = DateTime.Now
            };

            clientsRepository.Add(client);

            return new ClientsCreateResponse
            {
                id = client.id,
                firstName = client.first_name,
                lastName = client.last_name,
                email = client.email,
                phone = client.phone,
                address = client.address
            };
        }

        public ClientsUpdateResponse UpdateClient(ClientsUpdateRequest request)
        {
            var existingClient = clientsRepository.GetById(request.id);
            if (existingClient == null)
            {
                throw new ClientNotFoundException();
            }

            existingClient.first_name = request.first_name ?? existingClient.first_name;
            existingClient.last_name = request.last_name ?? existingClient.last_name;
            existingClient.email = request.email ?? existingClient.email;
            existingClient.phone = request.phone ?? existingClient.phone;
            existingClient.address = request.address ?? existingClient.address;

            clientsRepository.Update();

            return new ClientsUpdateResponse
            {
                id = existingClient.id,
                first_name = existingClient.first_name,
                last_name = existingClient.last_name,
                email = existingClient.email,
                phone = existingClient.phone,
                address = existingClient.address
            };
        }
        public void DeleteClient(int id)
        {
            var client = clientsRepository.GetById(id);
            if (client == null)
            {
                throw new ClientNotFoundException();
            }
            clientsRepository.Delete(client);
        }
    }
}
