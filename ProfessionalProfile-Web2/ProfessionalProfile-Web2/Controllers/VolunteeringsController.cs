using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfessionalProfile_Web2.Data;
using ProfessionalProfile_Web2.Models;

namespace ProfessionalProfile_Web2.Controllers
{
    public class VolunteeringsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VolunteeringsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Volunteerings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Volunteerings.Include(v => v.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Volunteerings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteering = await _context.Volunteerings
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.volunteeringId == id);
            if (volunteering == null)
            {
                return NotFound();
            }

            return View(volunteering);
        }

        // GET: Volunteerings/Create
        public IActionResult Create()
        {
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId");
            return View();
        }

        // POST: Volunteerings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("volunteeringId,userId,organisation,role,description")] Volunteering volunteering)
        {   
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                _context.Add(volunteering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", volunteering.userId);
            return View(volunteering);
        }

        // GET: Volunteerings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteering = await _context.Volunteerings.FindAsync(id);
            if (volunteering == null)
            {
                return NotFound();
            }
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", volunteering.userId);
            return View(volunteering);
        }

        // POST: Volunteerings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("volunteeringId,userId,organisation,role,description")] Volunteering volunteering)
        {
            if (id != volunteering.volunteeringId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volunteering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolunteeringExists(volunteering.volunteeringId))
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
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", volunteering.userId);
            return View(volunteering);
        }

        // GET: Volunteerings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteering = await _context.Volunteerings
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.volunteeringId == id);
            if (volunteering == null)
            {
                return NotFound();
            }

            return View(volunteering);
        }

        // POST: Volunteerings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volunteering = await _context.Volunteerings.FindAsync(id);
            if (volunteering != null)
            {
                _context.Volunteerings.Remove(volunteering);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VolunteeringExists(int id)
        {
            return _context.Volunteerings.Any(e => e.volunteeringId == id);
        }
    }
}
