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
    public class FollowingFeedController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public FollowingFeedController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/FollowingFeed
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FollowingFeedDTO>>> GetFollowingFeeds()
        {
            return await context.FollowingFeeds.Select(element => BaseToDTOConverters.Converter_FollowingFeedToDTO(element)).ToListAsync();
        }

        // GET: api/FollowingFeed/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FollowingFeedDTO>> GetFollowingFeed(int id)
        {
            var followingFeed = await context.FollowingFeeds.FindAsync(id);

            if (followingFeed == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_FollowingFeedToDTO(followingFeed);
        }

        // PUT: api/FollowingFeed/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollowingFeed(int id, FollowingFeedDTO followingFeed)
        {
            if (id != followingFeed.ID)
            {
                return BadRequest();
            }

            var followingFeedRef = DTOToBaseConverters.Converter_DTOToFollowingFeed(followingFeed);
            context.Entry(followingFeedRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowingFeedExists(id))
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

        private bool FollowingFeedExists(int id)
        {
            return context.FollowingFeeds.Any(e => e.ID == id);
        }

        // POST: api/FollowingFeed
        [HttpPost]
        public async Task<ActionResult<FollowingFeedDTO>> PostFollowingFeed(FollowingFeedDTO followingFeed)
        {
            var followingFeedRef = DTOToBaseConverters.Converter_DTOToFollowingFeed(followingFeed);
            context.FollowingFeeds.Add(followingFeedRef);
            await context.SaveChangesAsync();
            followingFeed.ID = followingFeedRef.ID;
            return CreatedAtAction("GetFollowingFeed", new { id = followingFeed.ID }, followingFeed);
        }

        // DELETE: api/FollowingFeed/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFollowingFeed(int id)
        {
            var followingFeed = await context.FollowingFeeds.FindAsync(id);
            if (followingFeed == null)
            {
                return NotFound();
            }

            context.FollowingFeeds.Remove(followingFeed);
            await context.SaveChangesAsync();

            return NoContent();
        }


    }
}
