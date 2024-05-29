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
    public class FollowingFeedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FollowingFeedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FollowingFeeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.FollowingFeeds.ToListAsync());
        }

        // GET: FollowingFeeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followingFeed = await _context.FollowingFeeds
                .FirstOrDefaultAsync(m => m.ID == id);
            if (followingFeed == null)
            {
                return NotFound();
            }

            return View(followingFeed);
        }

        // GET: FollowingFeeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FollowingFeeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ReactionThreshold")] FollowingFeed followingFeed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(followingFeed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(followingFeed);
        }

        // GET: FollowingFeeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followingFeed = await _context.FollowingFeeds.FindAsync(id);
            if (followingFeed == null)
            {
                return NotFound();
            }
            return View(followingFeed);
        }

        // POST: FollowingFeeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ReactionThreshold")] FollowingFeed followingFeed)
        {
            if (id != followingFeed.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(followingFeed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FollowingFeedExists(followingFeed.ID))
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
            return View(followingFeed);
        }

        // GET: FollowingFeeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followingFeed = await _context.FollowingFeeds
                .FirstOrDefaultAsync(m => m.ID == id);
            if (followingFeed == null)
            {
                return NotFound();
            }

            return View(followingFeed);
        }

        // POST: FollowingFeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var followingFeed = await _context.FollowingFeeds.FindAsync(id);
            if (followingFeed != null)
            {
                _context.FollowingFeeds.Remove(followingFeed);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FollowingFeedExists(int id)
        {
            return _context.FollowingFeeds.Any(e => e.ID == id);
        }
    }
}
