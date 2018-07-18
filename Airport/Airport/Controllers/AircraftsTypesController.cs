using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<List<AircraftType>> GetAircraftsTypes() => await Services.GetAllAsync();

        // GET api/AircraftsTypes/5
        [HttpGet("{id}")]
        public async Task<ObjectResult> GetAircraftTypeDetails(int id)
        {
            return Ok(await Services.GetDetailsAsync(id));
        }

        // POST api/AircraftsTypes
        [HttpPost]
        public async Task<ObjectResult> PostAircraftType([FromBody]AircraftType aircraftType)
        {
            if (aircraftType == null)
                return BadRequest("Enter correct entity");
            if (aircraftType.Id != 0)
                return BadRequest("You can`t enter the id");
            await Services.AddAsync(aircraftType);
            return Ok(aircraftType);
        }

        // PUT api/AircraftsTypes/5
        [HttpPut("{id}")]
        public async Task<ObjectResult> PutAircraftType(int id, [FromBody]AircraftType aircraftType)
        {
            if (aircraftType == null || await Services.IsExistAsync(id) == null)
                return NotFound("Entity with id = " + id + " not found");
            if (aircraftType.Id != id)
            {
                if (aircraftType.Id == 0) aircraftType.Id = id;
                else return BadRequest("You can`t change the id");
            }
            await Services.UpdateAsync(aircraftType);
            return Ok(aircraftType);
        }

        // DELETE api/AircraftsTypes/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteAircraftType(int id)
        {
            if (await Services.IsExistAsync(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            await Services.RemoveAsync(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/AircraftsTypes
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteAircraftsTypes()
        {
            await Services.RemoveAllAsync();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
