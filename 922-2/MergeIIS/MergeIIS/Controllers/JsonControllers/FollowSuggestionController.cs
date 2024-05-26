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
    public class FollowSuggestionController : ControllerBase
    {
        private readonly ProjectDBContext context;
        public FollowSuggestionController(ProjectDBContext context)
        {
            this.context = context;
        }

        //GET: api/FollowSuggestion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FollowSuggestionDTO>>> GetFollowSuggestion()
        {
            return await context.FollowSuggestions.Select(element => BaseToDTOConverters.Converter_FollowSuggestionDTO(element)).ToListAsync();
        }

        //GET: api/FollowSuggestion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FollowSuggestion>> GetFollowSuggestion(int id)
        {
            var followSuggestion = await context.FollowSuggestions.FindAsync(id);

            if (followSuggestion == null)
            {
                return NotFound();
            }

            return followSuggestion;
        }

        //PUT: api/FollowSuggestion/5
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollowSuggestion(int id, FollowSuggestionDTO followSuggestion)
        {
            if (id != followSuggestion.Id)
            {
                return BadRequest();
            }

            var followSuggestionRef = DTOToBaseConverters.Converter_DTOToFollowSuggestion(followSuggestion);
            context.Entry(followSuggestionRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowSuggestionExists(id))
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

        //POST: api/FollowSuggestion
        [HttpPost]
        public async Task<ActionResult<FollowSuggestion>> PostFollowSuggestion(FollowSuggestionDTO followSuggestion)
        {
            var followSuggestionRef = DTOToBaseConverters.Converter_DTOToFollowSuggestion(followSuggestion);
            context.FollowSuggestions.Add(followSuggestionRef);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetFollowSuggestion", new { id = followSuggestionRef.Id }, followSuggestionRef);
        }

        //DELETE: api/FollowSuggestion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFollowSuggestion(int id)
        {
            var followSuggestion = await context.FollowSuggestions.FindAsync(id);
            if (followSuggestion == null)
            {
                return NotFound();
            }

            context.FollowSuggestions.Remove(followSuggestion);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool FollowSuggestionExists(int id)
        {
            return context.FollowSuggestions.Any(e => e.Id == id);
        }
    }
}