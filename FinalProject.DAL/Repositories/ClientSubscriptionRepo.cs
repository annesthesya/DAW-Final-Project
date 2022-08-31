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
    public class ClientSubscriptionRepo : IClientSubscriptionRepo
    {
        private readonly AppDBContext _context;

        public ClientSubscriptionRepo(AppDBContext context)
        {
            _context = context;
        }

        public async Task Create(ClientSubscription clientSubscription)
        {

            clientSubscription.Total = _context.Subscriptions.Find(clientSubscription.SubscriptionId).DurationHours
                * _context.ParkingSpaces.Find(clientSubscription.ParkingSpaceId).PricePerHour;

            clientSubscription.EndDate = clientSubscription
                .StartDate
                .AddHours(_context.Subscriptions.Find(clientSubscription.SubscriptionId).DurationHours);

            await _context.ClientSubscriptions.AddAsync(clientSubscription);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var clientSubscription = _context.ClientSubscriptions.Find(id);
            _context.ClientSubscriptions.Remove(clientSubscription);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ClientSubscription>> GetAll()
        {
            var clientSubscriptions = await _context
                .ClientSubscriptions
                .ToListAsync();

            return clientSubscriptions;
        }

        public async Task<ClientSubscription> GetById(Guid id)
        {
            var clientSubscription = _context
                .ClientSubscriptions
                .Find(id);

            return clientSubscription;
        }

        public async Task<ClientSubscription> Update(ClientSubscription newClientSubscription)
        {
            var clientSubscription = _context
                .ClientSubscriptions
                .Find(newClientSubscription.Id);

            if (newClientSubscription.SubscriptionId != 0) 
                clientSubscription.SubscriptionId = newClientSubscription.SubscriptionId;
            if(newClientSubscription.CarLicensePlate != null) 
                clientSubscription.CarLicensePlate = newClientSubscription.CarLicensePlate;
            if(newClientSubscription.ParkingSpaceId != Guid.Parse("00000000-0000-0000-0000-000000000000")) 
                clientSubscription.ParkingSpaceId = newClientSubscription.ParkingSpaceId;

            clientSubscription.Total = _context.Subscriptions.Find(clientSubscription.SubscriptionId).DurationHours
                * _context.ParkingSpaces.Find(clientSubscription.ParkingSpaceId).PricePerHour;

            clientSubscription.EndDate = clientSubscription
                .StartDate
                .AddHours(_context.Subscriptions.Find(clientSubscription.SubscriptionId).DurationHours);

            await _context.SaveChangesAsync();

            var updatedClientSubscription = _context
                .ClientSubscriptions
                .Find(newClientSubscription.Id);

            return updatedClientSubscription;
        }
    }
}
