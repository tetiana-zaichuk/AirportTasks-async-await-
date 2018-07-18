using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class AircraftsController : Controller
    {
        private IService<Aircraft> Services { get; }

        public AircraftsController(IService<Aircraft> services) => Services = services;

        // GET api/Aircrafts
        [HttpGet]
        public List<Aircraft> GetAircrafts() => Services.GetAll();

        // GET api/Aircrafts/5
        [HttpGet("{id}")]
        public ObjectResult GetAircraftDetails(int id)
        {
            if (Services.IsExist(id) == null)
                return NotFound("Aircraft with id = " + id + " not found");
            return Ok(Services.GetDetails(id));
        }

        // POST api/Aircrafts
        [HttpPost]
        public ObjectResult PostAircraft([FromBody]Aircraft aircraft)
        {
            if (aircraft == null)
                return BadRequest("Enter correct entity");
            if (DateTime.Compare(aircraft.AircraftReleaseDate, DateTime.UtcNow) >= 0)
                return BadRequest("Wrong release date");
            if (!Services.ValidationForeignId(aircraft))
                return BadRequest("Wrong foreign id");
            if (aircraft.Id != 0)
                return BadRequest("You can`t enter the id");
            //aircraft.Id = Services.GetAll().Count + 1;
            Services.Add(aircraft);
            return Ok(aircraft);
        }

        // PUT api/Aircrafts/5
        [HttpPut("{id}")]
        public ObjectResult PutAircraft(int id, [FromBody]Aircraft aircraft)
        {
            if (aircraft == null || Services.IsExist(id) == null)
                return NotFound("Entity with id = " + id + " not found");
            if (DateTime.Compare(aircraft.AircraftReleaseDate, DateTime.UtcNow) >= 0)
                return BadRequest("Wrong release date");
            if (!Services.ValidationForeignId(aircraft))
                return BadRequest("Wrong foreign id");
            if (aircraft.Id != id)
            {
                if (aircraft.Id == 0) aircraft.Id = id;
                else return BadRequest("You can`t change the id");
            }
            Services.Update(aircraft);
            return Ok(aircraft);
        }

        // DELETE api/Aircrafts/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteAircraft(int id)
        {
            if (Services.IsExist(id) == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
        
        // DELETE api/Aircrafts
        [HttpDelete]
        public HttpResponseMessage DeleteAircrafts()
        {
            Services.RemoveAll();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
