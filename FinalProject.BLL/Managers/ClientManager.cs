using FinalProject.BLL.Interfaces;
using FinalProject.DAL.Interfaces;
using FinalProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Managers
{
    public class ClientManager : IClientManager
    {

        private readonly IClientRepo _clientRepository;

        public ClientManager(IClientRepo clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<string>> ShowAll()
        {
            var clients = await _clientRepository.GetAll();

            var strings = new List<string>();

            foreach (var client in clients)
            {
                strings.Add($"Name:{client.Name},ID:{client.Id}");
            }

            return strings;
        }
    }
}
