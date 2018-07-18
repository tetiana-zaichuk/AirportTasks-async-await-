using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        private IService<Flight> Services { get; }

        public FlightsController(IService<Flight> services) => Services = services;

        // GET api/Flights
        [HttpGet]
        public async Task<List<Flight>> GetFlights() => await Services.GetAllAsync();

        // GET api/Flights/5
        [HttpGet("{id}")]
        public async Task<ObjectResult> GetFlightDetails(int id)
        {
            if (await Services.IsExistAsync(id) == null) return NotFound("Flight with id = " + id + " not found");
            return Ok(await Services.GetDetailsAsync(id));
        }

        // POST api/Flights
        [HttpPost]
        public async Task<ObjectResult> PostFlight([FromBody]Flight flight)
        {
            if (flight == null)
                return BadRequest("Enter correct entity");
            if (flight.Id != 0)
                return BadRequest("You can`t enter the id");
            if (DateTime.Compare(flight.DepartureTime, flight.ArrivalTime) >= 0)
                return BadRequest("Wrong departure/arrival date");
            if (!await Services.ValidationForeignIdAsync(flight))
                return BadRequest("Wrong foreign id");
            await Services.AddAsync(flight);
            return Ok(flight);
        }

        // PUT api/Flights/5
        [HttpPut("{id}")]
        public async Task<ObjectResult> PutFlight(int id, [FromBody]Flight flight)
        {
            if (flight == null || await Services.IsExistAsync(id) == null)
                return NotFound("Entity with id = " + id + " not found");
            if (DateTime.Compare(flight.DepartureTime, flight.ArrivalTime) >= 0)
                return BadRequest("Wrong departure/arrival date");
            if (flight.Id != id)
            {
                if (flight.Id == 0) flight.Id = id;
                else return BadRequest("You can`t change the id");
            }
            if (!await Services.ValidationForeignIdAsync(flight))
                return BadRequest("Wrong foreign id");
            await Services.UpdateAsync(flight);
            return Ok(flight);
        }

        // DELETE api/Flights/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteFlight(int id)
        {
            if (await Services.IsExistAsync(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            await Services.RemoveAsync(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Flights
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteFlights()
        {
            await Services.RemoveAllAsync();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
