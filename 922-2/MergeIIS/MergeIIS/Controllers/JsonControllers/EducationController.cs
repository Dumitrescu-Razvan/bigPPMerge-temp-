using Microsoft.AspNetCore.Mvc;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace MergeIIS.Controllers.JsonControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : Controller
    {
        private readonly IEducationRepo _educationRepo;
        public EducationController(IEducationRepo educationRepo)
        {
            _educationRepo = educationRepo;
        }

        [HttpGet(Name = "GetAllEducations")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_educationRepo.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "EducationGetById")]
        [ProducesResponseType(200, Type = typeof(Education))]
        [ProducesResponseType(400)]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_educationRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddEducation")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Add([FromBody] Education education)
        {
            try
            {
                _educationRepo.Add(education);
                return CreatedAtRoute("EducationGetById", new { id = education.educationId }, education);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = "UpdateEducation")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Update([FromBody] Education education)
        {
            try
            {
                _educationRepo.Update(education);
                return Ok(education);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteEducation")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _educationRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}