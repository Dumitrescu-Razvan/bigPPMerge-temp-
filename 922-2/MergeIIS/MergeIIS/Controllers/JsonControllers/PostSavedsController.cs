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
    public class PostSavedsController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public PostSavedsController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/PostSaveds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostSavedDTO>>> GetPostSaved()
        {
            return await context.PostSaved.Select(element => BaseToDTOConverters.Converter_PostSavedToDTO(element)).ToListAsync();
        }

        // GET: api/PostSaveds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostSavedDTO>> GetPostSaved(int id)
        {
            var postSaved = await context.PostSaved.FindAsync(id);

            if (postSaved == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_PostSavedToDTO(postSaved);
        }

        // PUT: api/PostSaveds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostSaved(int id, PostSavedDTO postSaved)
        {
            if (id != postSaved.save_id)
            {
                return BadRequest();
            }

            var postSavedRef = DTOToBaseConverters.Converter_DTOToPostSaved(postSaved);
            context.Entry(postSavedRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostSavedExists(id))
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

        // POST: api/PostSaveds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostSavedDTO>> PostPostSaved(PostSavedDTO postSaved)
        {
            var postSavedRef = DTOToBaseConverters.Converter_DTOToPostSaved(postSaved);
            context.PostSaved.Add(postSavedRef);
            await context.SaveChangesAsync();

            postSaved.save_id = postSavedRef.save_id;
            return CreatedAtAction("GetPostSaved", new { id = postSaved.save_id }, postSaved);
        }

        // DELETE: api/PostSaveds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostSaved(int id)
        {
            var postSaved = await context.PostSaved.FindAsync(id);
            if (postSaved == null)
            {
                return NotFound();
            }

            context.PostSaved.Remove(postSaved);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostSavedExists(int id)
        {
            return context.PostSaved.Any(e => e.save_id == id);
        }
    }
}
