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
    public class PrivaciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrivaciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Privacies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Privacies.Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Privacies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privacy = await _context.Privacies
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (privacy == null)
            {
                return NotFound();
            }

            return View(privacy);
        }

        // GET: Privacies/Create
        public IActionResult Create()
        {
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId");
            return View();
        }

        // POST: Privacies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,userId,CanViewEducation,CanViewWorkExperience,CanViewSkills,CanViewProjects,CanViewCertificates,CanViewVolunteering")] Privacy privacy)
        {   
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                _context.Add(privacy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", privacy.userId);
            return View(privacy);
        }

        // GET: Privacies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privacy = await _context.Privacies.FindAsync(id);
            if (privacy == null)
            {
                return NotFound();
            }
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", privacy.userId);
            return View(privacy);
        }

        // POST: Privacies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,userId,CanViewEducation,CanViewWorkExperience,CanViewSkills,CanViewProjects,CanViewCertificates,CanViewVolunteering")] Privacy privacy)
        {
            if (id != privacy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(privacy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrivacyExists(privacy.Id))
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
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", privacy.userId);
            return View(privacy);
        }

        // GET: Privacies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privacy = await _context.Privacies
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (privacy == null)
            {
                return NotFound();
            }

            return View(privacy);
        }

        // POST: Privacies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var privacy = await _context.Privacies.FindAsync(id);
            if (privacy != null)
            {
                _context.Privacies.Remove(privacy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrivacyExists(int id)
        {
            return _context.Privacies.Any(e => e.Id == id);
        }
    }
}
