using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.DatabaseContext;
using Server.Models;

namespace MergeIIS.Controllers.JsonControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostReportedController : Controller
    {
        private readonly ProjectDBContext context;
        public PostReportedController(ProjectDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostReported>>> GetPostReported()
        {
            return await context.PostReported.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PostReported>> GetPostReported(int id)
        {
            var postReported = await context.PostReported.FindAsync(id);
            if (postReported == null)
            {
                return NotFound();
            }
            return postReported;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostReported(int id, PostReported postReported)
        {
            if (id != postReported.Report_Id)
            {
                return BadRequest();
            }
            context.Entry(postReported).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostReportedExists(id))
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

        private bool PostReportedExists(int id)
        {
            return context.PostReported.Any(e => e.Report_Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<PostReported>> PostPostReported(PostReported postReported)
        {
            context.PostReported.Add(postReported);
            await context.SaveChangesAsync();
            return CreatedAtAction("GetPostReported", new { id = postReported.Report_Id }, postReported);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostReported(int id)
        {
            var postReported = await context.PostReported.FindAsync(id);
            if (postReported == null)
            {
                return NotFound();
            }
            context.PostReported.Remove(postReported);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
