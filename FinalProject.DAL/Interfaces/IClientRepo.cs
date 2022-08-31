using FinalProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Interfaces
{
    public interface IClientRepo
    {
        Task Create(Client client);
        Task<Client> Update(Client client);
        Task Delete(Guid id);
        Task<List<Client>> GetAll();
        Task<Client> GetById(Guid id);

    }
}
