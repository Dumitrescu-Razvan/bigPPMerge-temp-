using Microsoft.AspNetCore.Mvc;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VolunteeringController : Controller
    {
        private readonly IVolunteeringRepo _volunteeringRepo;
        public VolunteeringController(IVolunteeringRepo volunteeringRepo)
        {
            _volunteeringRepo = volunteeringRepo;
        }

        [HttpGet(Name = "GetAllVolunteerings")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_volunteeringRepo.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "VolunteeringGetById")]
        [ProducesResponseType(200, Type = typeof(Volunteering))]
        [ProducesResponseType(400)]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_volunteeringRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddVolunteering")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Add([FromBody] Volunteering volunteering)
        {
            try
            {
                _volunteeringRepo.Add(volunteering);
                return CreatedAtRoute("VolunteeringGetById", new { id = volunteering.volunteeringId }, volunteering);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = "UpdateVolunteering")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Update([FromBody] Volunteering volunteering)
        {
            try
            {
                _volunteeringRepo.Update(volunteering);
                return Ok(volunteering);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteVolunteering")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _volunteeringRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}