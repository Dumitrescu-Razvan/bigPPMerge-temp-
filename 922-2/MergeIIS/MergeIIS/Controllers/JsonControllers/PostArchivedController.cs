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
    public class PostArchivedController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public PostArchivedController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/PostArchived
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostArchivedDTO>>> GetPostArchived()
        {
            return await context.PostArchived.Select(element => BaseToDTOConverters.Converter_PostArchivedToDTO(element)).ToListAsync();
        }

        // GET: api/PostArchived/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostArchivedDTO>> GetPostArchived(int id)
        {
            var postArchived = await context.PostArchived.FindAsync(id);

            if (postArchived == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_PostArchivedToDTO(postArchived);
        }

        // PUT: api/PostArchived/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostArchived(int id, PostArchivedDTO postArchived)
        {
            if (id != postArchived.post_id)
            {
                return BadRequest();
            }

            var postArchivedRef = DTOToBaseConverters.Converter_DTOToPostArchived(postArchived);
            context.Entry(postArchivedRef).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostArchivedExists(id))
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

        // POST: api/PostArchived
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostArchivedDTO>> PostPostArchived(PostArchivedDTO postArchived)
        {
            var postArchivedRef = DTOToBaseConverters.Converter_DTOToPostArchived(postArchived);
            context.PostArchived.Add(postArchivedRef);
            await context.SaveChangesAsync();
            postArchived.post_id = postArchivedRef.post_id;
            return CreatedAtAction("GetPostArchived", new { id = postArchived.post_id }, postArchived);
        }

        // DELETE: api/PostArchived/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostArchived(int id)
        {
            var postArchived = await context.PostArchived.FindAsync(id);
            if (postArchived == null)
            {
                return NotFound();
            }

            context.PostArchived.Remove(postArchived);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostArchivedExists(int id)
        {
            return context.PostArchived.Any(e => e.post_id == id);
        }
    }
}
