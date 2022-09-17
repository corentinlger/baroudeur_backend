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
    public class PointController : Controller
    {
        private readonly baroudeursContext _context;

        public PointController(baroudeursContext context)
        {
            _context = context;
        }

        // GET: Point
        public async Task<IActionResult> Index()
        {
            var baroudeursContext = _context.PointOfInterests.Include(p => p.City);
            return View(await baroudeursContext.ToListAsync());
        }

        // GET: Point/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfInterest = await _context.PointOfInterests
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return View(pointOfInterest);
        }

        // GET: Point/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            return View();
        }

        // POST: Point/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IsEssential,Theme,PointType,Latitude,Longitude,CityId")] PointOfInterest pointOfInterest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pointOfInterest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", pointOfInterest.CityId);
            return View(pointOfInterest);
        }

        // GET: Point/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfInterest = await _context.PointOfInterests.FindAsync(id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", pointOfInterest.CityId);
            return View(pointOfInterest);
        }

        // POST: Point/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,IsEssential,Theme,PointType,Latitude,Longitude,CityId")] PointOfInterest pointOfInterest)
        {
            if (id != pointOfInterest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pointOfInterest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PointOfInterestExists(pointOfInterest.Id))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", pointOfInterest.CityId);
            return View(pointOfInterest);
        }

        // GET: Point/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfInterest = await _context.PointOfInterests
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return View(pointOfInterest);
        }

        // POST: Point/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pointOfInterest = await _context.PointOfInterests.FindAsync(id);
            _context.PointOfInterests.Remove(pointOfInterest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PointOfInterestExists(int id)
        {
            return _context.PointOfInterests.Any(e => e.Id == id);
        }
    }
}
