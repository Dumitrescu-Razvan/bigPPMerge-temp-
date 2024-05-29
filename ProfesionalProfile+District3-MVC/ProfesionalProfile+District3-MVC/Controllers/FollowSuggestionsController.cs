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
    public class FollowSuggestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FollowSuggestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FollowSuggestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.FollowSuggestions.ToListAsync());
        }

        // GET: FollowSuggestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followSuggestion = await _context.FollowSuggestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (followSuggestion == null)
            {
                return NotFound();
            }

            return View(followSuggestion);
        }

        // GET: FollowSuggestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FollowSuggestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,userId,username,numberOfCommonFriends,numberOfCommonGroups,numberOfCommonOrganizations,numberOfCommonTags,location")] FollowSuggestion followSuggestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(followSuggestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(followSuggestion);
        }

        // GET: FollowSuggestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followSuggestion = await _context.FollowSuggestions.FindAsync(id);
            if (followSuggestion == null)
            {
                return NotFound();
            }
            return View(followSuggestion);
        }

        // POST: FollowSuggestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,userId,username,numberOfCommonFriends,numberOfCommonGroups,numberOfCommonOrganizations,numberOfCommonTags,location")] FollowSuggestion followSuggestion)
        {
            if (id != followSuggestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(followSuggestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FollowSuggestionExists(followSuggestion.Id))
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
            return View(followSuggestion);
        }

        // GET: FollowSuggestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followSuggestion = await _context.FollowSuggestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (followSuggestion == null)
            {
                return NotFound();
            }

            return View(followSuggestion);
        }

        // POST: FollowSuggestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var followSuggestion = await _context.FollowSuggestions.FindAsync(id);
            if (followSuggestion != null)
            {
                _context.FollowSuggestions.Remove(followSuggestion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FollowSuggestionExists(int id)
        {
            return _context.FollowSuggestions.Any(e => e.Id == id);
        }
    }
}
