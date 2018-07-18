using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Services;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class TicketsController : Controller
    {
        private IService<Ticket> Services { get; }

        public TicketsController(IService<Ticket> services) => Services = services;

        // GET api/Tickets
        [HttpGet]
        public async Task<List<Ticket>> GetTickets() => await Services.GetAllAsync();

        // GET api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ObjectResult> GetTicketDetails(int id)
        {
            if (await Services.IsExistAsync(id) == null)
                return NotFound("Aircraft with id = " + id + " not found");
            return Ok(await Services.GetDetailsAsync(id));
        }

        // POST api/Tickets
        [HttpPost]
        public async Task<ObjectResult> PostTicket([FromBody]Ticket ticket)
        {
            if (ticket == null)
                return BadRequest("Enter correct entity");
            if (!await Services.ValidationForeignIdAsync(ticket))
                return BadRequest("Wrong foreign id");
            if (ticket.Id != 0)
                return BadRequest("You can`t enter the id");
            await Services.AddAsync(ticket);
            return Ok(ticket);
        }

        // PUT api/Tickets/5
        [HttpPut("{id}")]
        public async Task<ObjectResult> PutTicket(int id, [FromBody]Ticket ticket)
        {
            if (ticket == null || Services.IsExistAsync(id) == null)
                return NotFound("Entity with id = " + id + " not found");
            if (!await Services.ValidationForeignIdAsync(ticket))
                return BadRequest("Wrong foreign id");
            if (ticket.Id != id)
            {
                if (ticket.Id == 0) ticket.Id = id;
                else return BadRequest("You can`t change the id");
            }
            await Services.UpdateAsync(ticket);
            return Ok(ticket);
        }

        // DELETE api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteTicket(int id)
        {
            if (await Services.IsExistAsync(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            await Services.RemoveAsync(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Tickets
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteTickets()
        {
            await Services.RemoveAllAsync();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
