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
    public class WorkExperiencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkExperiencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkExperiences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkExperiences.Include(w => w.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WorkExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperiences
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.workId == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

        // GET: WorkExperiences/Create
        public IActionResult Create()
        {
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId");
            return View();
        }

        // POST: WorkExperiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("workId,userId,jobTitle,company,location,employmentPeriod,responsibilities,achievements,description")] WorkExperience workExperience)
        {   
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                _context.Add(workExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", workExperience.userId);
            return View(workExperience);
        }

        // GET: WorkExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperiences.FindAsync(id);
            if (workExperience == null)
            {
                return NotFound();
            }
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", workExperience.userId);
            return View(workExperience);
        }

        // POST: WorkExperiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("workId,userId,jobTitle,company,location,employmentPeriod,responsibilities,achievements,description")] WorkExperience workExperience)
        {
            if (id != workExperience.workId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExperienceExists(workExperience.workId))
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
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", workExperience.userId);
            return View(workExperience);
        }

        // GET: WorkExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperiences
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.workId == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

        // POST: WorkExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workExperience = await _context.WorkExperiences.FindAsync(id);
            if (workExperience != null)
            {
                _context.WorkExperiences.Remove(workExperience);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkExperienceExists(int id)
        {
            return _context.WorkExperiences.Any(e => e.workId == id);
        }
    }
}
