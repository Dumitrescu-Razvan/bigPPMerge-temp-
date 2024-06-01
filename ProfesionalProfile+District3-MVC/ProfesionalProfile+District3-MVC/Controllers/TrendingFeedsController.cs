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
    public class TrendingFeedsController : Controller
    {
        private readonly ITrendingFeedRepository repository;

        public TrendingFeedsController(ITrendingFeedRepository trendingFeedRepository)
        {
            repository = trendingFeedRepository;
        }
        // GET: TrendingFeeds
        public async Task<IActionResult> Index()
        {
            var trendingFeeds = await repository.GetTrendingFeedsAsync();
            return View(trendingFeeds);
        }

        // GET: TrendingFeeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trendingFeed = await repository.GetTrendingFeedByIdAsync(id.Value);
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
            await repository.AddTrendingFeedAsync(trendingFeed);
            return View(trendingFeed);
        }

        // GET: TrendingFeeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trendingFeed = await repository.GetTrendingFeedByIdAsync(id.Value);
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
                   await repository.UpdateTrendingFeedAsync(trendingFeed);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var trendingFeedExists = await repository.TrendingFeedExistsAsync(trendingFeed.ID);
                    if (!trendingFeedExists)
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

            var trendingFeed = await repository.GetTrendingFeedByIdAsync(id.Value);
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
            await repository.DeleteTrendingFeedAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
