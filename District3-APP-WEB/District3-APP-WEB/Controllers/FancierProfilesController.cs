using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using District3_APP_WEB.Data;
using District3_APP_WEB.Models;

namespace District3_APP_WEB.Controllers
{
    public class FancierProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FancierProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FancierProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.FancierProfile.ToListAsync());
        }

        // GET: FancierProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fancierProfile = await _context.FancierProfile
                .FirstOrDefaultAsync(m => m.ProfileId == id);
            if (fancierProfile == null)
            {
                return NotFound();
            }

            return View(fancierProfile);
        }

        // GET: FancierProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FancierProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfileId,Links,DailyMotto,RemoveMottoDate,FrameNumber,Hashtag")] FancierProfile fancierProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fancierProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fancierProfile);
        }

        // GET: FancierProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fancierProfile = await _context.FancierProfile.FindAsync(id);
            if (fancierProfile == null)
            {
                return NotFound();
            }
            return View(fancierProfile);
        }

        // POST: FancierProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfileId,Links,DailyMotto,RemoveMottoDate,FrameNumber,Hashtag")] FancierProfile fancierProfile)
        {
            if (id != fancierProfile.ProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fancierProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FancierProfileExists(fancierProfile.ProfileId))
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
            return View(fancierProfile);
        }

        // GET: FancierProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fancierProfile = await _context.FancierProfile
                .FirstOrDefaultAsync(m => m.ProfileId == id);
            if (fancierProfile == null)
            {
                return NotFound();
            }

            return View(fancierProfile);
        }

        // POST: FancierProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fancierProfile = await _context.FancierProfile.FindAsync(id);
            if (fancierProfile != null)
            {
                _context.FancierProfile.Remove(fancierProfile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FancierProfileExists(int id)
        {
            return _context.FancierProfile.Any(e => e.ProfileId == id);
        }
    }
}
