using Microsoft.AspNetCore.Mvc;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrivacyController : Controller
    {
        private readonly IPrivacyRepo _privacyRepo;
        public PrivacyController(IPrivacyRepo privacyRepo)
        {
            _privacyRepo = privacyRepo;
        }

        [HttpGet(Name = "GetAllPrivacies")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_privacyRepo.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "PrivacyGetById")]
        [ProducesResponseType(200, Type = typeof(Privacy))]
        [ProducesResponseType(400)]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_privacyRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddPrivacy")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Add([FromBody] Privacy privacy)
        {
            try
            {
                _privacyRepo.Add(privacy);
                return CreatedAtRoute("PrivacyGetById", new { id = privacy.Id }, privacy);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = "UpdatePrivacy")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Update([FromBody] Privacy privacy)
        {
            try
            {
                _privacyRepo.Update(privacy);
                return Ok(privacy);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeletePrivacy")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _privacyRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}