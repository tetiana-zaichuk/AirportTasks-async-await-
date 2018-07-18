using System;
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
    public class DeparturesController : Controller
    {
        private IService<Departure> Services { get; }

        public DeparturesController(IService<Departure> services) => Services = services;

        // GET api/Departures
        [HttpGet]
        public List<Departure> GetDepartures() => Services.GetAll();

        // GET api/Departures/5
        [HttpGet("{id}")]
        public ObjectResult GetDepartureDetails(int id)
        {
            if (Services.IsExist(id) == null) return NotFound("Departure with id = " + id + " not found");
            return Ok(Services.GetDetails(id));
        }

        // POST api/Departures
        [HttpPost]
        public ObjectResult PostDeparture([FromBody]Departure departure)
        {
            if (departure == null)
                return BadRequest("Enter correct entity");
            if (DateTime.Compare(departure.DepartureDate, DateTime.UtcNow) < 0)
                return BadRequest("Wrong departure date");
            if (!Services.ValidationForeignId(departure))
                return BadRequest("Wrong foreign id");
            if (departure.Id != 0)
                return BadRequest("You can`t enter the id");
            Services.Add(departure);
            return Ok(departure);
        }

        // PUT api/Departures/5
        [HttpPut("{id}")]
        public ObjectResult PutDeparture(int id, [FromBody]Departure departure)
        {
            if (departure==null || Services.IsExist(id) == null)
                return NotFound("Entity with id = " + id + " not found");
            if (DateTime.Compare(departure.DepartureDate, DateTime.UtcNow) < 0)
                return BadRequest("Wrong departure date");
            if (!Services.ValidationForeignId(departure))
                return BadRequest("Wrong foreign id");
            if (departure.Id != id)
            {
                if (departure.Id==0) departure.Id = id;
                else return BadRequest("You can`t change the id");
            }
            Services.Update(departure);
            return Ok(departure);
        }

        // DELETE api/Departures/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteDeparture(int id)
        {
            if (Services.IsExist(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Departures
        [HttpDelete]
        public HttpResponseMessage DeleteDepartures()
        {
            Services.RemoveAll();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
