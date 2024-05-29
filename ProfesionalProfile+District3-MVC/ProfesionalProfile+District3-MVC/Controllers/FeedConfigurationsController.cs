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
    public class FeedConfigurationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedConfigurationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FeedConfigurations
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeedConfigurations.ToListAsync());
        }

        // GET: FeedConfigurations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedConfiguration = await _context.FeedConfigurations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (feedConfiguration == null)
            {
                return NotFound();
            }

            return View(feedConfiguration);
        }

        // GET: FeedConfigurations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FeedConfigurations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ReactionThreshold")] FeedConfiguration feedConfiguration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedConfiguration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feedConfiguration);
        }

        // GET: FeedConfigurations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedConfiguration = await _context.FeedConfigurations.FindAsync(id);
            if (feedConfiguration == null)
            {
                return NotFound();
            }
            return View(feedConfiguration);
        }

        // POST: FeedConfigurations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ReactionThreshold")] FeedConfiguration feedConfiguration)
        {
            if (id != feedConfiguration.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedConfiguration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedConfigurationExists(feedConfiguration.ID))
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
            return View(feedConfiguration);
        }

        // GET: FeedConfigurations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedConfiguration = await _context.FeedConfigurations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (feedConfiguration == null)
            {
                return NotFound();
            }

            return View(feedConfiguration);
        }

        // POST: FeedConfigurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedConfiguration = await _context.FeedConfigurations.FindAsync(id);
            if (feedConfiguration != null)
            {
                _context.FeedConfigurations.Remove(feedConfiguration);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedConfigurationExists(int id)
        {
            return _context.FeedConfigurations.Any(e => e.ID == id);
        }
    }
}
