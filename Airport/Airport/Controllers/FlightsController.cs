using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public List<Flight> GetFlights() => Services.GetAll();

        // GET api/Flights/5
        [HttpGet("{id}")]
        public ObjectResult GetFlightDetails(int id)
        {
            if (Services.IsExist(id) == null) return NotFound("Flight with id = " + id + " not found");
            return Ok(Services.GetDetails(id));
        }

        // POST api/Flights
        [HttpPost]
        public ObjectResult PostFlight([FromBody]Flight flight)
        {
            if (flight == null)
                return BadRequest("Enter correct entity");
            if (flight.Id != 0)
                return BadRequest("You can`t enter the id");
            if (DateTime.Compare(flight.DepartureTime, flight.ArrivalTime) >= 0)
                return BadRequest("Wrong departure/arrival date");
            if (!Services.ValidationForeignId(flight))
                return BadRequest("Wrong foreign id");
            Services.Add(flight);
            return Ok(flight);
        }

        // PUT api/Flights/5
        [HttpPut("{id}")]
        public ObjectResult PutFlight(int id, [FromBody]Flight flight)
        {
            if (flight == null || Services.IsExist(id) == null)
                return NotFound("Entity with id = " + id + " not found");
            if (DateTime.Compare(flight.DepartureTime, flight.ArrivalTime) >= 0)
                return BadRequest("Wrong departure/arrival date");
            if (flight.Id != id)
            {
                if (flight.Id == 0) flight.Id = id;
                else return BadRequest("You can`t change the id");
            }
            if (!Services.ValidationForeignId(flight))
                return BadRequest("Wrong foreign id");
            Services.Update(flight);
            return Ok(flight);
        }

        // DELETE api/Flights/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteFlight(int id)
        {
            if (Services.IsExist(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Flights
        [HttpDelete]
        public HttpResponseMessage DeleteFlights()
        {
            Services.RemoveAll();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
