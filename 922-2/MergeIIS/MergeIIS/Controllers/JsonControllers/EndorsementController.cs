using Microsoft.AspNetCore.Mvc;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace MergeIIS.Controllers.JsonControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EndorsementController : Controller
    {
        private readonly IEndorsementRepo _endorsementRepo;
        public EndorsementController(IEndorsementRepo endorsementRepo)
        {
            _endorsementRepo = endorsementRepo;
        }

        [HttpGet(Name = "GetAllEndorsements")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_endorsementRepo.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "EndorsementGetById")]
        [ProducesResponseType(200, Type = typeof(Endorsement))]
        [ProducesResponseType(400)]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_endorsementRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddEndorsement")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Add([FromBody] Endorsement endorsement)
        {
            try
            {
                _endorsementRepo.Add(endorsement);
                return CreatedAtRoute("EndorsementGetById", new { id = endorsement.endorsementId }, endorsement);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = "UpdateEndorsement")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Update([FromBody] Endorsement endorsement)
        {
            try
            {
                _endorsementRepo.Update(endorsement);
                return Ok(endorsement);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteEndorsement")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _endorsementRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}