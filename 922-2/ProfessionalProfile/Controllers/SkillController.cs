using Microsoft.AspNetCore.Mvc;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        private readonly ISkillRepo _skillRepo;
        public SkillController(ISkillRepo skillRepo)
        {
            _skillRepo = skillRepo;
        }

        [HttpGet(Name = "GetAllSkills")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_skillRepo.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "SkillGetById")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_skillRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddSkill")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Add([FromBody] Skill item)
        {
            try
            {
                _skillRepo.Add(item);
                return CreatedAtRoute("GetById", new { id = item.skillId }, item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = "UpdateSkill")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Update([FromBody] Skill item)
        {
            try
            {
                _skillRepo.Update(item);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteSkill")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _skillRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByUserId/{userId}", Name = "GetSkillsByUserId")]
        public IActionResult GetByUserId(int userId)
        {
            try
            {
                return Ok(_skillRepo.GetByUserId(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("GetIdByName/{skillName}", Name = "GetIdByName")]
        public IActionResult GetIdByName(string skillName)
        {
            try
            {
                return Ok(_skillRepo.GetIdByName(skillName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
