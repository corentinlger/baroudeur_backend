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
    public class APIDiscoveryController : ControllerBase
    {
        private readonly baroudeursContext _context;

        public APIDiscoveryController(baroudeursContext context)
        {
            _context = context;
        }

        // GET: api/APIDiscovery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discovery>>> GetDiscoveries()
        {
            return await _context.Discoveries.ToListAsync();
        }

        // GET: api/APIDiscovery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Discovery>> GetDiscovery(int id)
        {
            var discovery = await _context.Discoveries.FindAsync(id);

            if (discovery == null)
            {
                return NotFound();
            }

            return discovery;
        }

        // PUT: api/APIDiscovery/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscovery(int id, Discovery discovery)
        {
            if (id != discovery.Id)
            {
                return BadRequest();
            }

            _context.Entry(discovery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscoveryExists(id))
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

        // POST: api/APIDiscovery
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Discovery>> PostDiscovery(Discovery discovery)
        {
            _context.Discoveries.Add(discovery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiscovery", new { id = discovery.Id }, discovery);
        }

        // DELETE: api/APIDiscovery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscovery(int id)
        {
            var discovery = await _context.Discoveries.FindAsync(id);
            if (discovery == null)
            {
                return NotFound();
            }

            _context.Discoveries.Remove(discovery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiscoveryExists(int id)
        {
            return _context.Discoveries.Any(e => e.Id == id);
        }
    }
}
