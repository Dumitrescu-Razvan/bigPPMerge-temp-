using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class FollowingFeedsController : Controller
    {
        private readonly IFollowingFeedRepository repository;

        public FollowingFeedsController(IFollowingFeedRepository repository)
        {
            this.repository = repository;
        }

        // GET: FollowingFeeds
        public async Task<IActionResult> Index()
        {
            var followingFeeds = await repository.GetFollowingFeedsAsync();
            return View(followingFeeds);
        }

        // GET: FollowingFeeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followingFeed = await repository.GetFollowingFeedByIdAsync(id.Value);
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
            await repository.AddFollowingFeedAsync(followingFeed);
            return View(followingFeed);
        }

        // GET: FollowingFeeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followingFeed = await repository.GetFollowingFeedByIdAsync(id.Value);
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
                    await repository.UpdateFollowingFeedAsync(followingFeed);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = await repository.FollowingFeedExistsAsync(followingFeed.ID);
                    if (!exists)
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

            var followingFeed = await repository.GetFollowingFeedByIdAsync(id.Value);
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
            await repository.DeleteFollowingFeedAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
