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
    public class StewardessesController : Controller
    {
        private IService<Stewardess> Services { get; }

        public StewardessesController(IService<Stewardess> services) => Services = services;

        // GET api/Stewardesses
        [HttpGet]
        public async Task<List<Stewardess>> GetAircrafts() => await Services.GetAllAsync();

        // GET api/Stewardesses/5
        [HttpGet("{id}")]
        public async Task<ObjectResult> GetAircraftDetails(int id)
        {
            if (await Services.IsExistAsync(id) == null) return NotFound("Aircraft with id = " + id + " not found");
            return Ok(await Services.GetDetailsAsync(id));
        }

        // POST api/Stewardesses
        [HttpPost]
        public async Task<ObjectResult> PostStewardess([FromBody]Stewardess stewardess)
        {
            if (stewardess == null)
                return BadRequest("Enter correct entity");
            if (stewardess.Id != 0)
                return BadRequest("You can`t enter the id");
            await Services.AddAsync(stewardess);
            return Ok(stewardess);
        }

        // PUT api/Stewardesses/5
        [HttpPut("{id}")]
        public async Task<ObjectResult> PutStewardess(int id, [FromBody]Stewardess stewardess)
        {
            if (stewardess == null || await Services.IsExistAsync(id) == null)
                return NotFound("Entity with id = " + id + " not found");
            if (stewardess.Id != id)
            {
                if (stewardess.Id == 0) stewardess.Id = id;
                else return BadRequest("You can`t change the id");
            }
            await Services.UpdateAsync(stewardess);
            return Ok(stewardess);
        }

        // DELETE api/Stewardesses/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteStewardess(int id)
        {
            if (Services.IsExistAsync(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            await Services.RemoveAsync(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Stewardesses
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteStewardesses()
        {
            await Services.RemoveAllAsync();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
