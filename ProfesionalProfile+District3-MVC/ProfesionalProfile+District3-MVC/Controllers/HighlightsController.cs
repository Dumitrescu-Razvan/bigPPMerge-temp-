using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Repositories;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class HighlightsController : Controller
    {
        private HighlightRepository highlightRepository;

        public HighlightsController(ApplicationDbContext context)
        {
            highlightRepository = new HighlightRepository(context);
        }

        // GET: Highlights
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Highlight.Include(h => h.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Highlights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highlight = await _context.Highlight
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.HighlightId == id);
            if (highlight == null)
            {
                return NotFound();
            }

            return View(highlight);
        }

        // GET: Highlights/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Highlights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HighlightId,UserId,PostsIds,Name,CoverFilePath")] Highlight highlight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(highlight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", highlight.UserId);
            return View(highlight);
        }

        // GET: Highlights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highlight = await _context.Highlight.FindAsync(id);
            if (highlight == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", highlight.UserId);
            return View(highlight);
        }

        // POST: Highlights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HighlightId,UserId,PostsIds,Name,CoverFilePath")] Highlight highlight)
        {
            if (id != highlight.HighlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(highlight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HighlightExists(highlight.HighlightId))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", highlight.UserId);
            return View(highlight);
        }

        // GET: Highlights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highlight = await _context.Highlight
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.HighlightId == id);
            if (highlight == null)
            {
                return NotFound();
            }

            return View(highlight);
        }

        // POST: Highlights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var highlight = await _context.Highlight.FindAsync(id);
            if (highlight != null)
            {
                _context.Highlight.Remove(highlight);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HighlightExists(int id)
        {
            return _context.Highlight.Any(e => e.HighlightId == id);
        }
    }
}
