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
    public class FollowedFeedFollowedUsersController : ControllerBase
    {
        private readonly ProjectDBContext context;
        public FollowedFeedFollowedUsersController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/FollowedFeedFollowedUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FollowedFeedFollowedUsers>>> GetFollowedFeedFollowedUsers()
        {
            return await context.FollowedFeedFollowedUsers.ToListAsync();
        }

        // GET: api/FollowedFeedFollowedUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FollowedFeedFollowedUsers>> GetFollowedFeedFollowedUsers(int id)
        {
            var followedFeedFollowedUsers = await context.FollowedFeedFollowedUsers.FindAsync(id);

            if (followedFeedFollowedUsers == null)
            {
                return new NotFoundResult();
            }

            return followedFeedFollowedUsers;
        }

        // PUT: api/FollowedFeedFollowedUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollowedFeedFollowedUsers(int id, FollowedFeedFollowedUsers FollowedFeedFollowedUsers)
        {
            if (id != FollowedFeedFollowedUsers.ID)
            {
                return new BadRequestResult();
            }

            context.Entry(FollowedFeedFollowedUsers).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowedFeedFollowedUsersExists(id))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }

            return new NoContentResult();
        }

        private bool FollowedFeedFollowedUsersExists(int id)
        {
            return context.FollowedFeedFollowedUsers.Any(e => e.ID == id);
        }

        // POST: api/FollowedFeedFollowedUsers
        [HttpPost]
        public async Task<ActionResult<FollowedFeedFollowedUsers>> PostFollowedFeedFollowedUsers(FollowedFeedFollowedUsers followedFeedFollowedUsers)
        {
            context.FollowedFeedFollowedUsers.Add(followedFeedFollowedUsers);
            await context.SaveChangesAsync();


            return CreatedAtAction("GetFollowedFeedFollowedUsers", new { id = followedFeedFollowedUsers.ID }, followedFeedFollowedUsers);
        }
        // DELETE: api/FollowedFeedFollowedUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFollowedFeedFollowedUsers(int id)
        {
            var followedFeedFollowedUsers = await context.FollowedFeedFollowedUsers.FindAsync(id);
            if (followedFeedFollowedUsers == null)
            {
                return new NotFoundResult();
            }

            context.FollowedFeedFollowedUsers.Remove(followedFeedFollowedUsers);
            await context.SaveChangesAsync();

            return new NoContentResult();
        }

    }
}
