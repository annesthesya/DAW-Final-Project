using FinalProject.BLL.Interfaces;
using FinalProject.DAL;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientManager _clientManager;
        private readonly IClientRepo _clientRepository;
        private readonly AppDBContext _context;

        public ClientController(IClientManager clientManager, IClientRepo clientRepository, AppDBContext context)
        {
            _clientManager = clientManager;
            _clientRepository = clientRepository;
            _context = context;
        }

        [HttpPost("CreateClient")]
        [Authorize("Admin")]
        public async Task<ActionResult> CreateClient([FromBody] Client client)
        {
            await _clientRepository.Create(client);
            return Ok("Client Added Successfully");
        }

        [HttpGet("ReadClient/{id}")]
        [Authorize("Admin")]
        public async Task<ActionResult>ReadClient([FromRoute] Guid id)
        {
            var client = _clientRepository.GetById(id);
            if (client == null)
                return NotFound("Client with that ID does not exist.");
            return Ok(client);
        }

        [HttpGet("GetClientsShow")] 
        [Authorize("Admin")]
        public async Task<ActionResult> GetClients() 
        {
            var clients = await _clientManager.ShowAll();
            return Ok(clients);
        }

        [HttpPut("UpdateClient")]
        [Authorize("Admin")]
        public async Task<ActionResult> UpdateClient([FromBody] Client client)
        {
            var updatedClient = _clientRepository.Update(client);
            if (updatedClient == null)
                return NotFound("Client with that ID does not exist. Update failed.");
            return Ok("Update Successful.");
        }

        [HttpGet("DeleteClient/{id}")]
        [Authorize("Admin")]
        public async Task<ActionResult> DeleteClient([FromRoute] Guid id)
        {
            await _clientRepository.Delete(id);
            return Ok("Client Deleted Successfully");
        }

        [HttpGet("GetClientsJoinWhere")]
        public async Task<ActionResult> GetClientsJoinWhere()
        {

            var clientsWithMoreCars = await _context
                .Clients
                .Include(x => x.Cars)
                .Include(x => x.ClientSubscriptions)
                .Where(x => x.Cars.Count > 1)
                .ToListAsync();

            return Ok(clientsWithMoreCars);
        }

        [HttpGet("ClientsAndCarsLinqJoin")]
        public async Task<ActionResult> ClientsAndCarsLinqJoin()
        {

            try
            {
                var clients = _context.Clients;
                var join = _context.Cars.Join(clients, b => b.ClientId, a => a.Id, (b, a) => new
                {
                    ClientId = b.ClientId,
                    Name = a.Name,
                    Car = b.Manufacturer + b.Model,
                    LicensePlate = b.LicensePlateNumber
                });

                return Ok(join);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }

}

