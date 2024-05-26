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
    public class TrendingFeedController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public TrendingFeedController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/TrendingFeed
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrendingFeedDTO>>> GetTrendingFeeds()
        {
            return await context.TrendingFeeds.Select(element => BaseToDTOConverters.Converter_TrendingFeedToDTO(element)).ToListAsync();
        }

        // GET: api/TrendingFeed/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrendingFeedDTO>> GetTrendingFeed(int id)
        {
            var trendingFeed = await context.TrendingFeeds.FindAsync(id);

            if (trendingFeed == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_TrendingFeedToDTO(trendingFeed);
        }

        // PUT: api/TrendingFeed/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrendingFeed(int id, TrendingFeedDTO trendingFeed)
        {
            if (id != trendingFeed.ID)
            {
                return BadRequest();
            }

            var trendingFeedRef = DTOToBaseConverters.Converter_DTOToTrendingFeed(trendingFeed);
            context.Entry(trendingFeedRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrendingFeedExists(id))
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

        private bool TrendingFeedExists(int id)
        {
            return context.TrendingFeeds.Any(e => e.ID == id);
        }

        // POST: api/TrendingFeed
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrendingFeedDTO>> PostTrendingFeed(TrendingFeedDTO trendingFeed)
        {
            var trendingFeedRef = DTOToBaseConverters.Converter_DTOToTrendingFeed(trendingFeed);
            context.TrendingFeeds.Add(trendingFeedRef);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetTrendingFeed", new { id = trendingFeedRef.ID }, BaseToDTOConverters.Converter_TrendingFeedToDTO(trendingFeedRef));
        }

        // DELETE: api/TrendingFeed/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrendingFeed(int id)
        {
            var trendingFeed = await context.TrendingFeeds.FindAsync(id);
            if (trendingFeed == null)
            {
                return NotFound();
            }

            context.TrendingFeeds.Remove(trendingFeed);
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}