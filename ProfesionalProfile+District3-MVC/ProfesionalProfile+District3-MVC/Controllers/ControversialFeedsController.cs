using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class ControversialFeedsController : Controller
    {
        private readonly IControversialFeedRepository repository;

        public ControversialFeedsController(IControversialFeedRepository repository)
        {
            this.repository = repository;
        }

        // GET: ControversialFeeds
        public async Task<IActionResult> Index()
        {
            var controversialFeeds = await repository.GetControversialFeedsAsync();
            return View(controversialFeeds);
        }

        // GET: ControversialFeeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controversialFeed = await repository.GetControversialFeedByIdAsync(id.Value);
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
            await repository.AddControversialFeedAsync(controversialFeed);
            return View(controversialFeed);
        }

        // GET: ControversialFeeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controversialFeed = await repository.GetControversialFeedByIdAsync(id.Value);
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
                   await repository.UpdateControversialFeedAsync(controversialFeed);
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

            var controversialFeed = await repository.GetControversialFeedByIdAsync(id.Value);
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
          
            
            await repository.DeleteControversialFeedAsync(id);
            
            return RedirectToAction(nameof(Index));
        }

        private bool ControversialFeedExists(int id)
        {
            return repository.ControversialFeedExists(id);
        }
    }
}
