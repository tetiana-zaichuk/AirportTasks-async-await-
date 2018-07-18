using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
        public List<Ticket> GetTickets() => Services.GetAll();

        // GET api/Tickets/5
        [HttpGet("{id}")]
        public ObjectResult GetTicketDetails(int id)
        {
            if (Services.IsExist(id) == null)
                return NotFound("Aircraft with id = " + id + " not found");
            return Ok(Services.GetDetails(id));
        }

        // POST api/Tickets
        [HttpPost]
        public ObjectResult PostTicket([FromBody]Ticket ticket)
        {
            if (ticket == null)
                return BadRequest("Enter correct entity");
            if (!Services.ValidationForeignId(ticket))
                return BadRequest("Wrong foreign id");
            if (ticket.Id != 0)
                return BadRequest("You can`t enter the id");
            Services.Add(ticket);
            return Ok(ticket);
        }

        // PUT api/Tickets/5
        [HttpPut("{id}")]
        public ObjectResult PutTicket(int id, [FromBody]Ticket ticket)
        {
            if (ticket == null || Services.IsExist(id) == null)
                return NotFound("Entity with id = " + id + " not found");
            if (!Services.ValidationForeignId(ticket))
                return BadRequest("Wrong foreign id");
            if (ticket.Id != id)
            {
                if (ticket.Id == 0) ticket.Id = id;
                else return BadRequest("You can`t change the id");
            }
            Services.Update(ticket);
            return Ok(ticket);
        }

        // DELETE api/Tickets/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteTicket(int id)
        {
            if (Services.IsExist(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Tickets
        [HttpDelete]
        public HttpResponseMessage DeleteTickets()
        {
            Services.RemoveAll();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
