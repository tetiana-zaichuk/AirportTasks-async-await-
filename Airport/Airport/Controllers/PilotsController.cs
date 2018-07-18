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
    public class PilotsController : Controller
    {
        private IService<Pilot> Services { get; }

        public PilotsController(IService<Pilot> services) => Services = services;

        // GET api/Pilots
        [HttpGet]
        public async Task<List<Pilot>> GetPilots() => await Services.GetAllAsync();

        // GET api/Pilots/5
        [HttpGet("{id}")]
        public async Task<ObjectResult> GetPilotDetails(int id)
        {
            if (await Services.IsExistAsync(id) == null) return NotFound("Aircraft with id = " + id + " not found");
            return Ok(await Services.GetDetailsAsync(id));
        }

        // POST api/Pilots
        [HttpPost]
        public async Task<ObjectResult> PostPilot([FromBody]Pilot pilot)
        {
            if (pilot == null)
                return BadRequest("Enter correct entity");
            if (pilot.Id != 0)
                return BadRequest("You can`t enter the id");
            await Services.AddAsync(pilot);
            return Ok(pilot);
        }

        // PUT api/Pilots/5
        [HttpPut("{id}")]
        public async Task<ObjectResult> PutPilot(int id, [FromBody]Pilot pilot)
        {
            if (pilot == null || await Services.IsExistAsync(id) == null)
                return NotFound("Entity with id = " + id + " not found");
            if (pilot.Id != id)
            {
                if (pilot.Id == 0) pilot.Id = id;
                else return BadRequest("You can`t change the id");
            }
            await Services.UpdateAsync(pilot);
            return Ok(pilot);
        }

        // DELETE api/Pilots/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeletePilot(int id)
        {
            if (await Services.IsExistAsync(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            await Services.RemoveAsync(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Pilots
        [HttpDelete]
        public async Task<HttpResponseMessage> DeletePilots()
        {
            await Services.RemoveAllAsync();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
