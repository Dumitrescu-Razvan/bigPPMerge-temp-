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
    public class LocationsController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public LocationsController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDTO>>> GetLocations()
        {
            return await context.Locations.Select(element => BaseToDTOConverters.Converter_LocationToDTO(element)).ToListAsync();
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDTO>> GetLocation(int id)
        {
            var location = await context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_LocationToDTO(location);
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, LocationDTO location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            var locationRef = DTOToBaseConverters.Converter_DTOToLocation(location);
            context.Entry(locationRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LocationDTO>> PostLocation(LocationDTO location)
        {
            var locationRef = DTOToBaseConverters.Converter_DTOToLocation(location);
            context.Locations.Add(locationRef);
            await context.SaveChangesAsync();

            location.Id = locationRef.Id;
            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            context.Locations.Remove(location);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationExists(int id)
        {
            return context.Locations.Any(e => e.Id == id);
        }
    }
}
