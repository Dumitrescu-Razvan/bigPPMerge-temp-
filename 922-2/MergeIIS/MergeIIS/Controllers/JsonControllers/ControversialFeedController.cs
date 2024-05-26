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
    public class ControversialFeedController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public ControversialFeedController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/ControversialFeed
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ControversialFeedDTO>>> GetControversialFeeds()
        {
            return await context.ControversialFeeds.Select(element => BaseToDTOConverters.Converter_ControversialFeedToDTO(element)).ToListAsync();
        }

        // GET: api/ControversialFeed/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ControversialFeedDTO>> GetControversialFeed(int id)
        {
            var controversialFeed = await context.ControversialFeeds.FindAsync(id);

            if (controversialFeed == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_ControversialFeedToDTO(controversialFeed);
        }

        // PUT: api/ControversialFeed/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutControversialFeed(int id, ControversialFeedDTO controversialFeed)
        {
            if (id != controversialFeed.ID)
            {
                return BadRequest();
            }

            var controversialFeedRef = DTOToBaseConverters.Converter_DTOToControversialFeed(controversialFeed);
            context.Entry(controversialFeedRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ControversialFeedExists(id))
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

        private bool ControversialFeedExists(int id)
        {
            return context.ControversialFeeds.Any(e => e.ID == id);
        }

        // POST: api/ControversialFeed
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ControversialFeedDTO>> PostControversialFeed(ControversialFeedDTO controversialFeed)
        {
            var controversialFeedRef = DTOToBaseConverters.Converter_DTOToControversialFeed(controversialFeed);
            context.ControversialFeeds.Add(controversialFeedRef);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetControversialFeed", new { id = controversialFeed.ID }, controversialFeed);
        }

        // DELETE: api/ControversialFeed/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteControversialFeed(int id)
        {
            var controversialFeed = await context.ControversialFeeds.FindAsync(id);
            if (controversialFeed == null)
            {
                return NotFound();
            }

            context.ControversialFeeds.Remove(controversialFeed);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}