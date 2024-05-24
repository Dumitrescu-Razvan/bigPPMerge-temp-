using Microsoft.AspNetCore.Mvc;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkExperienceController : Controller
    {
        private readonly IWorkExperienceRepo _workExperienceRepo;
        public WorkExperienceController(IWorkExperienceRepo workExperienceRepo)
        {
            _workExperienceRepo = workExperienceRepo;
        }

        [HttpGet(Name = "GetAllWorkExperiences")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_workExperienceRepo.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "WorkExperienceGetById")]
        [ProducesResponseType(200, Type = typeof(WorkExperience))]
        [ProducesResponseType(400)]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_workExperienceRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddWorkExperience")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Add([FromBody] WorkExperience workExperience)
        {
            try
            {
                _workExperienceRepo.Add(workExperience);
                return CreatedAtRoute("WorkExperienceGetById", new { id = workExperience.workId }, workExperience);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = "UpdateWorkExperience")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Update([FromBody] WorkExperience workExperience)
        {
            try
            {
                _workExperienceRepo.Update(workExperience);
                return Ok(workExperience);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteWorkExperience")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _workExperienceRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}