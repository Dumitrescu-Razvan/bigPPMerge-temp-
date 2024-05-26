using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.DatabaseContext;
using Server.DTOs;
using Server.Models;
using Server.Utils;

namespace MergeIIS.Controllers.JsonControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowsController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public FollowsController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/Follows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FollowDTO>>> GetFollow()
        {
            return await context.Follow.Select(element => BaseToDTOConverters.Converter_FollowToDTO(element)).ToListAsync();
        }

        // GET: api/Follows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Follow>> GetFollow(int id)
        {
            var follow = await context.Follow.FindAsync(id);

            if (follow == null)
            {
                return NotFound();
            }

            return follow;
        }

        // PUT: api/Follows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollow(int id, FollowDTO follow)
        {
            if (id != follow.Id)
            {
                return BadRequest();
            }

            var followRef = DTOToBaseConverters.Converter_DTOToFollow(follow);
            context.Entry(followRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Follows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Follow>> PostFollow(FollowDTO follow)
        {
            var followRef = DTOToBaseConverters.Converter_DTOToFollow(follow);
            context.Follow.Add(followRef);
            await context.SaveChangesAsync();

            follow.Id = followRef.Id;
            return CreatedAtAction("GetFollow", new { id = follow.Id }, follow);
        }

        // DELETE: api/Follows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFollow(int id)
        {
            var follow = await context.Follow.FindAsync(id);
            if (follow == null)
            {
                return NotFound();
            }

            context.Follow.Remove(follow);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool FollowExists(int id)
        {
            return context.Follow.Any(e => e.Id == id);
        }
    }
}
