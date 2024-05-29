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
    public class ControversialFeedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ControversialFeedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ControversialFeeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.ControversialFeeds.ToListAsync());
        }

        // GET: ControversialFeeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controversialFeed = await _context.ControversialFeeds
                .FirstOrDefaultAsync(m => m.ID == id);
            if (controversialFeed == null)
            {
                return NotFound();
            }

            return View(controversialFeed);
        }

        // GET: ControversialFeeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ControversialFeeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ReactionThreshold,MinimumReactionCount,MinimumCommentCount")] ControversialFeed controversialFeed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(controversialFeed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(controversialFeed);
        }

        // GET: ControversialFeeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controversialFeed = await _context.ControversialFeeds.FindAsync(id);
            if (controversialFeed == null)
            {
                return NotFound();
            }
            return View(controversialFeed);
        }

        // POST: ControversialFeeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ReactionThreshold,MinimumReactionCount,MinimumCommentCount")] ControversialFeed controversialFeed)
        {
            if (id != controversialFeed.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controversialFeed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControversialFeedExists(controversialFeed.ID))
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
            return View(controversialFeed);
        }

        // GET: ControversialFeeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controversialFeed = await _context.ControversialFeeds
                .FirstOrDefaultAsync(m => m.ID == id);
            if (controversialFeed == null)
            {
                return NotFound();
            }

            return View(controversialFeed);
        }

        // POST: ControversialFeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var controversialFeed = await _context.ControversialFeeds.FindAsync(id);
            if (controversialFeed != null)
            {
                _context.ControversialFeeds.Remove(controversialFeed);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControversialFeedExists(int id)
        {
            return _context.ControversialFeeds.Any(e => e.ID == id);
        }
    }
}
