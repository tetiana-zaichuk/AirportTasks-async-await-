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
    public class CrewController : Controller
    {
        private IServiceCrew Services { get; }

        public CrewController(IServiceCrew services) => Services = services;

        // GET api/Crew/Crew10
        [Route("Crew10")]
        [HttpGet]
        public async Task<List<Crew>> GetCrew10() => await Services.Get10Async();

        // GET api/Crew
        [HttpGet]
        public async Task<List<Crew>> GetCrews() => await Services.GetAllAsync();

        // GET api/Crew/5
        [HttpGet("{id}")]
        public async Task<ObjectResult> GetCrewDetails(int id)
        {
            if (await Services.IsExistAsync(id) == null) return NotFound("Crew with id = " + id + " not found");
            return Ok(await Services.GetDetailsAsync(id));
        }

        // POST api/Crew
        [HttpPost]
        public async Task<ObjectResult> PostCrew([FromBody]Crew crew)
        {
            if (crew == null)
                return BadRequest("Enter correct entity");
            if (!await Services.ValidationForeignIdAsync(crew))
                return BadRequest("Wrong foreign id");
            if (crew.Id != 0)
                return BadRequest("You can`t enter the id");
            await Services.AddAsync(crew);
            return Ok(crew);
        }

        // PUT api/Crew/5
        [HttpPut("{id}")]
        public async Task<ObjectResult> PutCrew(int id, [FromBody]Crew crew)
        {
            if (crew == null || await Services.IsExistAsync(id) == null)
                return NotFound("Entity with id = " + id + " not found");
            if (!await Services.ValidationForeignIdAsync(crew))
                return BadRequest("Wrong foreign id");
            if (crew.Id != id)
            {
                if (crew.Id == 0) crew.Id = id;
                else return BadRequest("You can`t change the id");
            }
            await Services.UpdateAsync(crew);
            return Ok(crew);
        }

        // DELETE api/Crew/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteCrew(int id)
        {
            if (await Services.IsExistAsync(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            await Services.RemoveAsync(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Crew
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteCrews()
        {
            await Services.RemoveAllAsync();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
