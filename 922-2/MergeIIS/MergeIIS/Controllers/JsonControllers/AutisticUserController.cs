using Microsoft.AspNetCore.Mvc;
using District3API.domain;
using District3API.RepoInterfaces;

namespace MergeIIS.Controllers.JsonControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutisticUserController : Controller
    {
        private readonly IRepoInterface<AutisticUser> _userRepo;
        public AutisticUserController(IRepoInterface<AutisticUser> userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet(Name = "GetAllAutisticUsers")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userRepo.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "AutisticUserGetById")]
        [ProducesResponseType(200, Type = typeof(AutisticUser))]
        [ProducesResponseType(400)]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_userRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddAutisticUser")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Add([FromBody] AutisticUser user)
        {
            try
            {
                _userRepo.Add(user);
                return CreatedAtRoute("GetById", new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = "UpdateAutisticUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Update([FromBody] AutisticUser user)
        {
            try
            {
                _userRepo.Update(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteAutisticUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _userRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
