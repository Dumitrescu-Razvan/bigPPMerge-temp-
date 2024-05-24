using Microsoft.AspNetCore.Mvc;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;
using ProfessionalProfile.repo;

namespace ProfessionalProfile.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssessmentTestController : Controller
    {
        private readonly IAssessmentTestRepo _assessmentTestRepo;
        public AssessmentTestController(IAssessmentTestRepo assessmentTestRepo)
        {
            _assessmentTestRepo = assessmentTestRepo;
        }

        [HttpGet(Name = "GetAllAssessmentTests")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_assessmentTestRepo.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "AssessmentTestGetById")]
        [ProducesResponseType(200, Type = typeof(AssessmentTest))]
        [ProducesResponseType(400)]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_assessmentTestRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddAssessmentTest")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Add([FromBody] AssessmentTest assessmentTest)
        {
            try
            {
                _assessmentTestRepo.Add(assessmentTest);
                return CreatedAtRoute("AssessmentTestGetById", new { id = assessmentTest.assessmentTestId }, assessmentTest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = "UpdateAssessmentTest")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Update([FromBody] AssessmentTest assessmentTest)
        {
            try
            {
                _assessmentTestRepo.Update(assessmentTest);
                return Ok(assessmentTest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteAssessmentTest")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _assessmentTestRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}