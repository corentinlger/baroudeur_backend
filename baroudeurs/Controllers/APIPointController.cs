using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using baroudeurs.Models;

namespace baroudeurs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIPointController : ControllerBase
    {
        private readonly baroudeursContext _context;

        public APIPointController(baroudeursContext context)
        {
            _context = context;
        }

        // GET: api/APIPoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterest>>> GetPointOfInterests()
        {
            return await _context.PointOfInterests.ToListAsync();
        }

        // GET: api/APIPoint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PointOfInterest>> GetPointOfInterest(int id)
        {
            var pointOfInterest = await _context.PointOfInterests.FindAsync(id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return pointOfInterest;
        }

        // PUT: api/APIPoint/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPointOfInterest(int id, PointOfInterest pointOfInterest)
        {
            if (id != pointOfInterest.Id)
            {
                return BadRequest();
            }

            _context.Entry(pointOfInterest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointOfInterestExists(id))
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

        // POST: api/APIPoint
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PointOfInterest>> PostPointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointOfInterests.Add(pointOfInterest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPointOfInterest", new { id = pointOfInterest.Id }, pointOfInterest);
        }

        // DELETE: api/APIPoint/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePointOfInterest(int id)
        {
            var pointOfInterest = await _context.PointOfInterests.FindAsync(id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }

            _context.PointOfInterests.Remove(pointOfInterest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PointOfInterestExists(int id)
        {
            return _context.PointOfInterests.Any(e => e.Id == id);
        }
    }
}
