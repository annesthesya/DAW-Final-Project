using FinalProject.DAL.Entities;
using FinalProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Repositories
{
    public class ClientRepo : IClientRepo
    {
        private readonly AppDBContext _context;

        public ClientRepo(AppDBContext context)
        {
            _context = context;
        }

        public async Task Create(Client client)
        {
            client.Created = DateTime.Now;
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var client = _context.Clients.Find(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAll()
        {
            var clients = await _context
                .Clients
                .ToListAsync();

            return clients;
        }

        public async Task<Client> GetById(Guid id)
        {
            var client = _context
                .Clients
                .Find(id);

            return client;
        }

        public async Task<Client> Update(Client newClient)
        {
            var client = _context
                .Clients
                .Find(newClient.Id);

            client.Name = newClient.Name;
            client.Email = newClient.Email;
            client.PhoneNo = newClient.PhoneNo;

            await _context.SaveChangesAsync();

            var updatedClient = _context
                .Clients
                .Find(newClient.Id);

            return updatedClient;
        }
    }
}
