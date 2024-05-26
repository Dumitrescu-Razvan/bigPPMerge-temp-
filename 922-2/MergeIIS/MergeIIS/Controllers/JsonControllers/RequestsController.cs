using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.DTOs;
using Server.DatabaseContext;
using System.Xml.Linq;
using Server.Utils;

namespace MergeIIS.Controllers.JsonControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public RequestsController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestDTO>>> GetRequests()
        {
            return await context.Requests.Select(element => BaseToDTOConverters.Converter_RequestToDTO(element)).ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestDTO>> GetRequest(int id)
        {
            var request = await context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_RequestToDTO(request);
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, RequestDTO request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var requestRef = DTOToBaseConverters.Converter_DTOToRequest(request);
            context.Entry(requestRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // POST: api/Requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequestDTO>> PostRequest(RequestDTO request)
        {
            var requestRef = DTOToBaseConverters.Converter_DTOToRequest(request);
            context.Requests.Add(requestRef);
            await context.SaveChangesAsync();


            request.Id = requestRef.Id;
            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            context.Requests.Remove(request);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestExists(int id)
        {
            return context.Requests.Any(e => e.Id == id);
        }
    }
}
