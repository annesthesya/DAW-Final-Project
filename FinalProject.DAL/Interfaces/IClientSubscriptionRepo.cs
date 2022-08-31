using FinalProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Interfaces
{
    public interface IClientSubscriptionRepo
    {
        Task Create(ClientSubscription clientSubscription);
        Task<ClientSubscription> Update(ClientSubscription clientSubscription);
        Task Delete(Guid id);
        Task<List<ClientSubscription>> GetAll();
        Task<ClientSubscription> GetById(Guid id);

    }
}
