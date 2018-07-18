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
    public class AircraftsController : Controller
    {
        private IService<Aircraft> Services { get; }

        public AircraftsController(IService<Aircraft> services) => Services = services;

        // GET api/Aircrafts
        [HttpGet]
        public async Task<List<Aircraft>> GetAircrafts() => await Services.GetAllAsync();

        // GET api/Aircrafts/5
        [HttpGet("{id}")]
        public async Task<ObjectResult> GetAircraftDetails(int id)
        {
            if (await Services.IsExistAsync(id) == null)
                return NotFound("Aircraft with id = " + id + " not found");
            return Ok(await Services.GetDetailsAsync(id));
        }

        // POST api/Aircrafts
        [HttpPost]
        public async Task<ObjectResult> PostAircraft([FromBody]Aircraft aircraft)
        {
            if (aircraft == null)
                return BadRequest("Enter correct entity");
            if (DateTime.Compare(aircraft.AircraftReleaseDate, DateTime.UtcNow) >= 0)
                return BadRequest("Wrong release date");
            if (!await Services.ValidationForeignIdAsync(aircraft))
                return BadRequest("Wrong foreign id");
            if (aircraft.Id != 0)
                return BadRequest("You can`t enter the id");
            //aircraft.Id = Services.GetAllAsync().Count + 1;
            await Services.AddAsync(aircraft);
            return Ok(aircraft);
        }

        // PUT api/Aircrafts/5
        [HttpPut("{id}")]
        public async Task<ObjectResult> PutAircraft(int id, [FromBody]Aircraft aircraft)
        {
            if (aircraft == null || Services.IsExistAsync(id) == null)
                return NotFound("Entity with id = " + id + " not found");
            if (DateTime.Compare(aircraft.AircraftReleaseDate, DateTime.UtcNow) >= 0)
                return BadRequest("Wrong release date");
            if (!await Services.ValidationForeignIdAsync(aircraft))
                return BadRequest("Wrong foreign id");
            if (aircraft.Id != id)
            {
                if (aircraft.Id == 0) aircraft.Id = id;
                else return BadRequest("You can`t change the id");
            }
            await Services.UpdateAsync(aircraft);
            return Ok(aircraft);
        }

        // DELETE api/Aircrafts/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteAircraft(int id)
        {
            if (await Services.IsExistAsync(id) == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            await Services.RemoveAsync(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
        
        // DELETE api/Aircrafts
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteAircrafts()
        {
            await Services.RemoveAllAsync();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
