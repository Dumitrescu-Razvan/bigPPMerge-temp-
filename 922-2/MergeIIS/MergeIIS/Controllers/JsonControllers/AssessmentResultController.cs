using Microsoft.AspNetCore.Mvc;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace MergeIIS.Controllers.JsonControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssessmentResultController : Controller
    {
        private readonly IAssessmentResultRepo _assessmentResultRepo;
        public AssessmentResultController(IAssessmentResultRepo assessmentResultRepo)
        {
            _assessmentResultRepo = assessmentResultRepo;
        }

        [HttpGet(Name = "GetAllAssessmentResults")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_assessmentResultRepo.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "AssessmentResultGetById")]
        [ProducesResponseType(200, Type = typeof(AssessmentResult))]
        [ProducesResponseType(400)]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_assessmentResultRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddAssessmentResult")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Add([FromBody] AssessmentResult assessmentResult)
        {
            try
            {
                _assessmentResultRepo.Add(assessmentResult);
                return CreatedAtRoute("AssessmentResultGetById", new { id = assessmentResult.assesmentResultId }, assessmentResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = "UpdateAssessmentResult")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Update([FromBody] AssessmentResult assessmentResult)
        {
            try
            {
                _assessmentResultRepo.Update(assessmentResult);
                return Ok(assessmentResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteAssessmentResult")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _assessmentResultRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}