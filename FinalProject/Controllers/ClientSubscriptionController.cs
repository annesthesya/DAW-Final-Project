using FinalProject.BLL.Interfaces;
using FinalProject.DAL;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientSubscriptionController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IClientSubscriptionRepo _clientSubscriptionRepository;

        public ClientSubscriptionController(IClientSubscriptionRepo clientSubscriptionRepository, AppDBContext context)
        {
            _clientSubscriptionRepository = clientSubscriptionRepository;
            _context = context;
        }

        [HttpPost("CreateClientSubscription")]
        [Authorize("Admin")]
        public async Task<ActionResult> CreateClientSubscription([FromBody] ClientSubscription clientSubscription)
        {
            await _clientSubscriptionRepository.Create(clientSubscription);
            return Ok("Client Subscription Added Successfully");
        }

        [HttpGet("ReadClientSubscription/{id}")]
        [Authorize("Admin")]
        public async Task<ActionResult> ReadClientSubscription([FromRoute] Guid id)
        {
            var clientSubscription = _clientSubscriptionRepository.GetById(id);
            if (clientSubscription == null)
                return NotFound("Client Subscription with that ID does not exist.");
            return Ok(clientSubscription);
        }

        [HttpGet("GetClientSubscriptionsShow")]
        [Authorize("Admin")]
        public async Task<ActionResult> GetClientSubscriptions()
        {
            var clientSubscriptions = await _context
                .ClientSubscriptions
                .ToListAsync();

            var strings = new List<string>();

            foreach (var clientSubscription in clientSubscriptions)
            {
                strings.Add($"Total:{clientSubscription.Total},ID:{clientSubscription.Id}");
            }

            return Ok(strings);
        }

        [HttpPut("UpdateClientSubscription")]
        [Authorize("Admin")]
        public async Task<ActionResult> UpdateClientSubscription([FromBody] ClientSubscription clientSubscription)
        {
            var updatedClientSubscription = _clientSubscriptionRepository.Update(clientSubscription);
            if (updatedClientSubscription == null)
                return NotFound("Client Subscription with that ID does not exist. Update failed.");
            return Ok("Update Successful.");
        }

        [HttpGet("DeleteClientSubscription/{id}")]
        [Authorize("Admin")]
        public async Task<ActionResult> DeleteClientSubscription([FromRoute] Guid id)
        {
            await _clientSubscriptionRepository.Delete(id);
            return Ok("Client Subscription Deleted Successfully");
        }

        [HttpGet("GetClientSubscriptionsOrderBy")]
        public async Task<ActionResult> GetClientSubscriptionsOrderBy()
        {

            var clientSubscriptions = await _context
                .ClientSubscriptions
                .Include(x => x.Client)
                .Where(x => x.Client.Id == Guid.Parse("A14BF13F-DB9C-4497-28DE-08DA7E091A4C"))
                .OrderBy(x => x.Total)
                .ToListAsync();

            return Ok(clientSubscriptions);
        }

        [HttpGet("GetClientSubscriptionsOrderByDescending")]
        public async Task<ActionResult> GetClientSubscriptionsOrderByDescending()
        {

            var clientSubscriptions = await _context
                .ClientSubscriptions
                .Include(x => x.Client)
                .Where(x => x.Client.Id == Guid.Parse("A14BF13F-DB9C-4497-28DE-08DA7E091A4C"))
                .OrderByDescending(x => x.Total)
                .ToListAsync();

            return Ok(clientSubscriptions);
        }

        [HttpGet("GetGroupBy")]
        public async Task<ActionResult> GetGroupBy()
        {
            try
            {
                var grouped = _context
                    .ClientSubscriptions
                    .GroupBy(x => x.ClientId)
                    .Select(x => new {
                        Key = x.Key,
                        Average = x.Average(y => y.Total)
                    });

                return Ok(grouped);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
