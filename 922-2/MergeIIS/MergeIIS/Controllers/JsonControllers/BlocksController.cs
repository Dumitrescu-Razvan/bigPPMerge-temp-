using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    public class BlocksController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public BlocksController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/Blocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlockDTO>>> GetBlock()
        {
            return await context.Block.Select(element => BaseToDTOConverters.Converter_BlockToDTO(element)).ToListAsync();
        }

        // GET: api/Blocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Block>> GetBlock(int id)
        {
            var block = await context.Block.FindAsync(id);

            if (block == null)
            {
                return NotFound();
            }

            return block;
        }

        // PUT: api/Blocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlock(int id, BlockDTO block)
        {
            if (id != block.Id)
            {
                return BadRequest();
            }

            var blockRef = DTOToBaseConverters.Converter_DTOToBlock(block);
            context.Entry(blockRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlockExists(id))
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

        // POST: api/Blocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Block>> PostBlock(BlockDTO block)
        {
            var blockRef = DTOToBaseConverters.Converter_DTOToBlock(block);
            context.Block.Add(blockRef);
            await context.SaveChangesAsync();

            block.Id = blockRef.Id;
            return CreatedAtAction("GetBlock", new { id = block.Id }, block);
        }

        // DELETE: api/Blocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlock(int id)
        {
            var block = await context.Block.FindAsync(id);
            if (block == null)
            {
                return NotFound();
            }

            context.Block.Remove(block);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlockExists(int id)
        {
            return context.Block.Any(e => e.Id == id);
        }
    }
}
