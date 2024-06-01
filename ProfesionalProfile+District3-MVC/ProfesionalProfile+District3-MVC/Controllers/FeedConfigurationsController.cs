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
    public class FeedConfigurationsController : Controller
    {
        private readonly IFeedConfigurationRepository repository;

        public FeedConfigurationsController(IFeedConfigurationRepository repository)
        {
            this.repository = repository;
        }

        // GET: FeedConfigurations
        public async Task<IActionResult> Index()
        {
            var feedConfigurations = await repository.GetFeedConfigurationsAsync();
            return View(feedConfigurations);
        }

        // GET: FeedConfigurations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedConfiguration = await repository.GetFeedConfigurationByIdAsync(id.Value);
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
            await repository.AddFeedConfigurationAsync(feedConfiguration);
            return View(feedConfiguration);
        }

        // GET: FeedConfigurations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedConfiguration = await repository.GetFeedConfigurationByIdAsync(id.Value);
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
                    await repository.UpdateFeedConfigurationAsync(feedConfiguration);
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

            var feedConfiguration = await repository.GetFeedConfigurationByIdAsync(id.Value);
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
            await repository.DeleteFeedConfigurationAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool FeedConfigurationExists(int id)
        {
            return repository.FeedConfigurationExists(id);
        }
    }
}
