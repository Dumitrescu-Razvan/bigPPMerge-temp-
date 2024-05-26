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
    public class FeedConfigurationController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public FeedConfigurationController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/FeedConfiguration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedConfigurationDTO>>> GetFeedConfigurations()
        {
            return await context.FeedConfigurations.Select(element => BaseToDTOConverters.Converter_FeedConfigurationToDTO(element)).ToListAsync();
        }

        // GET: api/FeedConfiguration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedConfigurationDTO>> GetFeedConfiguration(int id)
        {
            var feedConfiguration = await context.FeedConfigurations.FindAsync(id);

            if (feedConfiguration == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_FeedConfigurationToDTO(feedConfiguration);
        }

        // PUT: api/FeedConfiguration/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedConfiguration(int id, FeedConfigurationDTO feedConfiguration)
        {
            if (id != feedConfiguration.ID)
            {
                return BadRequest();
            }

            var feedConfigurationRef = DTOToBaseConverters.Converter_DTOToFeedConfiguration(feedConfiguration);
            context.Entry(feedConfigurationRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedConfigurationExists(id))
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

        private bool FeedConfigurationExists(int id)
        {
            return context.FeedConfigurations.Any(e => e.ID == id);
        }

        // POST: api/FeedConfiguration
        [HttpPost]
        public async Task<ActionResult<FeedConfigurationDTO>> PostFeedConfiguration(FeedConfigurationDTO feedConfiguration)
        {
            var feedConfigurationRef = DTOToBaseConverters.Converter_DTOToFeedConfiguration(feedConfiguration);
            context.FeedConfigurations.Add(feedConfigurationRef);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetFeedConfiguration", new { id = feedConfigurationRef.ID }, BaseToDTOConverters.Converter_FeedConfigurationToDTO(feedConfigurationRef));
        }

        // DELETE: api/FeedConfiguration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedConfiguration(int id)
        {
            var feedConfiguration = await context.FeedConfigurations.FindAsync(id);
            if (feedConfiguration == null)
            {
                return NotFound();
            }

            context.FeedConfigurations.Remove(feedConfiguration);
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
