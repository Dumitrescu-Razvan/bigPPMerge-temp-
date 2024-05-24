using Microsoft.AspNetCore.Mvc;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessCardController : Controller
    {
        private readonly IBusinessCardRepo _businessCardRepo;
        public BusinessCardController(IBusinessCardRepo businessCardRepo)
        {
            _businessCardRepo = businessCardRepo;
        }

        [HttpGet(Name = "GetAllBusinessCards")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_businessCardRepo.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "BusinessCardGetById")]
        [ProducesResponseType(200, Type = typeof(BusinessCard))]
        [ProducesResponseType(400)]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_businessCardRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddBusinessCard")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Add([FromBody] BusinessCard businessCard)
        {
            try
            {
                _businessCardRepo.Add(businessCard);
                return CreatedAtRoute("BusinessCardGetById", new { id = businessCard.bcId }, businessCard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = "UpdateBusinessCard")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Update([FromBody] BusinessCard businessCard)
        {
            try
            {
                _businessCardRepo.Update(businessCard);
                return Ok(businessCard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteBusinessCard")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _businessCardRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}