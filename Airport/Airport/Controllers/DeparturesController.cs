using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class DeparturesController : Controller
    {
        private IService<Departure> Services { get; }

        public DeparturesController(IService<Departure> services) => Services = services;

        // GET api/Departures
        [HttpGet]
        public async Task<List<Departure>> GetDepartures() => await Services.GetAllAsync();

        // GET api/Departures/5
        [HttpGet("{id}")]
        public async Task<ObjectResult> GetDepartureDetails(int id)
        {
            if (await Services.IsExistAsync(id) == null) return NotFound("Departure with id = " + id + " not found");
            return Ok(await Services.GetDetailsAsync(id));
        }

        // POST api/Departures
        [HttpPost]
        public async Task<ObjectResult> PostDeparture([FromBody]Departure departure)
        {
            if (departure == null)
                return BadRequest("Enter correct entity");
            if (DateTime.Compare(departure.DepartureDate, DateTime.UtcNow) < 0)
                return BadRequest("Wrong departure date");
            if (!await Services.ValidationForeignIdAsync(departure))
                return BadRequest("Wrong foreign id");
            if (departure.Id != 0)
                return BadRequest("You can`t enter the id");
            await Services.AddAsync(departure);
            return Ok(departure);
        }

        // PUT api/Departures/5
        [HttpPut("{id}")]
        public async Task<ObjectResult> PutDeparture(int id, [FromBody]Departure departure)
        {
            if (departure==null || await Services.IsExistAsync(id) == null)
                return NotFound("Entity with id = " + id + " not found");
            if (DateTime.Compare(departure.DepartureDate, DateTime.UtcNow) < 0)
                return BadRequest("Wrong departure date");
            if (!await Services.ValidationForeignIdAsync(departure))
                return BadRequest("Wrong foreign id");
            if (departure.Id != id)
            {
                if (departure.Id==0) departure.Id = id;
                else return BadRequest("You can`t change the id");
            }
            await Services.UpdateAsync(departure);
            return Ok(departure);
        }

        // DELETE api/Departures/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteDeparture(int id)
        {
            if (await Services.IsExistAsync(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            await Services.RemoveAsync(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Departures
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteDepartures()
        {
            await Services.RemoveAllAsync();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
