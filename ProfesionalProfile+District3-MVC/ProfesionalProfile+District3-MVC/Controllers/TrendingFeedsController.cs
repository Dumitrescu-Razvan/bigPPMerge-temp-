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
    public class TrendingFeedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrendingFeedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TrendingFeeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrendingFeeds.ToListAsync());
        }

        // GET: TrendingFeeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trendingFeed = await _context.TrendingFeeds
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trendingFeed == null)
            {
                return NotFound();
            }

            return View(trendingFeed);
        }

        // GET: TrendingFeeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrendingFeeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ReactionThreshold,LikeCount,ViewCount,CommentCount")] TrendingFeed trendingFeed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trendingFeed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trendingFeed);
        }

        // GET: TrendingFeeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trendingFeed = await _context.TrendingFeeds.FindAsync(id);
            if (trendingFeed == null)
            {
                return NotFound();
            }
            return View(trendingFeed);
        }

        // POST: TrendingFeeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ReactionThreshold,LikeCount,ViewCount,CommentCount")] TrendingFeed trendingFeed)
        {
            if (id != trendingFeed.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trendingFeed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrendingFeedExists(trendingFeed.ID))
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
            return View(trendingFeed);
        }

        // GET: TrendingFeeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trendingFeed = await _context.TrendingFeeds
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trendingFeed == null)
            {
                return NotFound();
            }

            return View(trendingFeed);
        }

        // POST: TrendingFeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trendingFeed = await _context.TrendingFeeds.FindAsync(id);
            if (trendingFeed != null)
            {
                _context.TrendingFeeds.Remove(trendingFeed);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrendingFeedExists(int id)
        {
            return _context.TrendingFeeds.Any(e => e.ID == id);
        }
    }
}
