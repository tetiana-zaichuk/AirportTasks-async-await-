using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AircraftsTypes : Controller
    {
        private IService<AircraftType> Services { get; }

        public AircraftsTypes(IService<AircraftType> services) => Services = services;

        // GET api/AircraftsTypes
        [HttpGet]
        public List<AircraftType> GetAircraftsTypes() => Services.GetAll();

        // GET api/AircraftsTypes/5
        [HttpGet("{id}")]
        public ObjectResult GetAircraftTypeDetails(int id)
        {
            return Ok(Services.GetDetails(id));
        }

        // POST api/AircraftsTypes
        [HttpPost]
        public ObjectResult PostAircraftType([FromBody]AircraftType aircraftType)
        {
            if (aircraftType == null)
                return BadRequest("Enter correct entity");
            if (aircraftType.Id != 0)
                return BadRequest("You can`t enter the id");
            Services.Add(aircraftType);
            return Ok(aircraftType);
        }

        // PUT api/AircraftsTypes/5
        [HttpPut("{id}")]
        public ObjectResult PutAircraftType(int id, [FromBody]AircraftType aircraftType)
        {
            if (aircraftType == null || Services.IsExist(id) == null)
                return NotFound("Entity with id = " + id + " not found");
            if (aircraftType.Id != id)
            {
                if (aircraftType.Id == 0) aircraftType.Id = id;
                else return BadRequest("You can`t change the id");
            }
            Services.Update(aircraftType);
            return Ok(aircraftType);
        }

        // DELETE api/AircraftsTypes/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteAircraftType(int id)
        {
            if (Services.IsExist(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/AircraftsTypes
        [HttpDelete]
        public HttpResponseMessage DeleteAircraftsTypes()
        {
            Services.RemoveAll();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
