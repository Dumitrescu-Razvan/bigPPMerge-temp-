using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.DatabaseContext;
using Server.DTOs;
using Server.Utils;
using Server.Models;

namespace MergeIIS.Controllers.JsonControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public PostsController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPosts()
        {
            return await context.Posts.Select(element => BaseToDTOConverters.Converter_PostToDTO(element)).ToListAsync();
        }

        [HttpGet("{postid}")]
        public async Task<ActionResult<PostDTO>> GetPost(int postid)
        {
            var post = await context.Posts.FindAsync(postid);
            if (post == null)
            {
                return NotFound();
            }
            return BaseToDTOConverters.Converter_PostToDTO(post);
        }

        [HttpPut("{postid}")]
        public async Task<IActionResult> PutPost(int postid, PostDTO post)
        {

            if (postid != post.Post_Id)
            {
                return BadRequest();
            }

            var postRef = DTOToBaseConverters.Converter_DTOToPost(post);
            context.Entry(postRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(postid))
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

        [HttpPost]
        public async Task<ActionResult<PostDTO>> PostPost(PostDTO post)
        {
            var postRef = DTOToBaseConverters.Converter_DTOToPost(post);
            context.Posts.Add(postRef);
            await context.SaveChangesAsync();

            post.Post_Id = postRef.Post_Id;
            return CreatedAtAction("GetPost", new { postid = post.Post_Id }, post);
        }

        [HttpDelete("{postid}")]
        public async Task<IActionResult> DeletePost(int postid)
        {
            var post = await context.Posts.FindAsync(postid);
            if (post == null)
            {
                return NotFound();
            }

            context.Posts.Remove(post);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int postid)
        {
            return context.Posts.Any(e => e.Post_Id == postid);
        }
    }
}