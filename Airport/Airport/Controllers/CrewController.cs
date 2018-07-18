using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class CrewController : Controller
    {
        private IService<Crew> Services { get; }

        public CrewController(IService<Crew> services) => Services = services;

        // GET api/Crew
        [HttpGet]
        public List<Crew> GetCrews() => Services.GetAll();

        // GET api/Crew/5
        [HttpGet("{id}")]
        public ObjectResult GetCrewDetails(int id)
        {
            if (Services.IsExist(id) == null) return NotFound("Crew with id = " + id + " not found");
            return Ok(Services.GetDetails(id));
        }

        // POST api/Crew
        [HttpPost]
        public ObjectResult PostCrew([FromBody]Crew crew)
        {
            if (crew == null)
                return BadRequest("Enter correct entity");
            if (!Services.ValidationForeignId(crew))
                return BadRequest("Wrong foreign id");
            if (crew.Id != 0)
                return BadRequest("You can`t enter the id");
            Services.Add(crew);
            return Ok(crew);
        }

        // PUT api/Crew/5
        [HttpPut("{id}")]
        public ObjectResult PutCrew(int id, [FromBody]Crew crew)
        {
            if (crew == null || Services.IsExist(id) == null)
                return NotFound("Entity with id = " + id + " not found");
            if (!Services.ValidationForeignId(crew))
                return BadRequest("Wrong foreign id");
            if (crew.Id != id)
            {
                if (crew.Id == 0) crew.Id = id;
                else return BadRequest("You can`t change the id");
            }
            Services.Update(crew);
            return Ok(crew);
        }

        // DELETE api/Crew/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteCrew(int id)
        {
            if (Services.IsExist(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Crew
        [HttpDelete]
        public HttpResponseMessage DeleteCrews()
        {
            Services.RemoveAll();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
