using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class CloseFriendProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CloseFriendProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CloseFriendProfiles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CloseFriendProfile.Include(c => c.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CloseFriendProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var closeFriendProfile = await _context.CloseFriendProfile
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (closeFriendProfile == null)
            {
                return NotFound();
            }

            return View(closeFriendProfile);
        }

        // GET: CloseFriendProfiles/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: CloseFriendProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,CloseFriendedDate")] CloseFriendProfile closeFriendProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(closeFriendProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", closeFriendProfile.UserId);
            return View(closeFriendProfile);
        }

        // GET: CloseFriendProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var closeFriendProfile = await _context.CloseFriendProfile.FindAsync(id);
            if (closeFriendProfile == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", closeFriendProfile.UserId);
            return View(closeFriendProfile);
        }

        // POST: CloseFriendProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,CloseFriendedDate")] CloseFriendProfile closeFriendProfile)
        {
            if (id != closeFriendProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(closeFriendProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CloseFriendProfileExists(closeFriendProfile.Id))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", closeFriendProfile.UserId);
            return View(closeFriendProfile);
        }

        // GET: CloseFriendProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var closeFriendProfile = await _context.CloseFriendProfile
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (closeFriendProfile == null)
            {
                return NotFound();
            }

            return View(closeFriendProfile);
        }

        // POST: CloseFriendProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var closeFriendProfile = await _context.CloseFriendProfile.FindAsync(id);
            if (closeFriendProfile != null)
            {
                _context.CloseFriendProfile.Remove(closeFriendProfile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CloseFriendProfileExists(int id)
        {
            return _context.CloseFriendProfile.Any(e => e.Id == id);
        }
    }
}
