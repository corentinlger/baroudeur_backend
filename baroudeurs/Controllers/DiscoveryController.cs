using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using baroudeurs.Models;

namespace baroudeurs.Controllers
{
    public class DiscoveryController : Controller
    {
        private readonly baroudeursContext _context;

        public DiscoveryController(baroudeursContext context)
        {
            _context = context;
        }

        // GET: Discovery
        public async Task<IActionResult> Index()
        {
            var baroudeursContext = _context.Discoveries.Include(a => a.Point).Include(d => d.User);
            return View(await baroudeursContext.ToListAsync());
        }

        // GET: Discovery/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discovery = await _context.Discoveries
                .Include(a => a.Point)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discovery == null)
            {
                return NotFound();
            }

            return View(discovery);
        }

        // GET: Discovery/Create
        public IActionResult Create()
        {
            ViewData["PointId"] = new SelectList(_context.PointOfInterests, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Username");
            return View();
        }

        // POST: Discovery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,PointId,TimeOfDiscovery")] Discovery discovery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discovery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PointId"] = new SelectList(_context.PointOfInterests, "Id", "Name", discovery.PointId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Username", discovery.UserId);
            return View(discovery);
        }

        // GET: Discovery/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discovery = await _context.Discoveries.FindAsync(id);
            if (discovery == null)
            {
                return NotFound();
            }
            ViewData["PointId"] = new SelectList(_context.PointOfInterests, "Id", "Name", discovery.PointId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Username", discovery.UserId);
            return View(discovery);
        }

        // POST: Discovery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,PointId,TimeOfDiscovery")] Discovery discovery)
        {
            if (id != discovery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discovery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscoveryExists(discovery.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PointId"] = new SelectList(_context.PointOfInterests, "Id", "Name", discovery.PointId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Username", discovery.UserId);
            return View(discovery);
        }

        // GET: Discovery/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discovery = await _context.Discoveries
                .Include(d => d.Point)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discovery == null)
            {
                return NotFound();
            }

            return View(discovery);
        }

        // POST: Discovery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discovery = await _context.Discoveries.FindAsync(id);
            _context.Discoveries.Remove(discovery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscoveryExists(int id)
        {
            return _context.Discoveries.Any(e => e.Id == id);
        }
    }
}
