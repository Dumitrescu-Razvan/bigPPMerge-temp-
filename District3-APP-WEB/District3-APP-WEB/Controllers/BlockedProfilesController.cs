﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using District3_APP_WEB.Data;
using District3_APP_WEB.Models;

namespace District3_APP_WEB.Controllers
{
    public class BlockedProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlockedProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BlockedProfiles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BlockedProfile.Include(b => b.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BlockedProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blockedProfile = await _context.BlockedProfile
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blockedProfile == null)
            {
                return NotFound();
            }

            return View(blockedProfile);
        }

        // GET: BlockedProfiles/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: BlockedProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,BlockDate")] BlockedProfile blockedProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blockedProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", blockedProfile.UserId);
            return View(blockedProfile);
        }

        // GET: BlockedProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blockedProfile = await _context.BlockedProfile.FindAsync(id);
            if (blockedProfile == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", blockedProfile.UserId);
            return View(blockedProfile);
        }

        // POST: BlockedProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,BlockDate")] BlockedProfile blockedProfile)
        {
            if (id != blockedProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blockedProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlockedProfileExists(blockedProfile.Id))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", blockedProfile.UserId);
            return View(blockedProfile);
        }

        // GET: BlockedProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blockedProfile = await _context.BlockedProfile
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blockedProfile == null)
            {
                return NotFound();
            }

            return View(blockedProfile);
        }

        // POST: BlockedProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blockedProfile = await _context.BlockedProfile.FindAsync(id);
            if (blockedProfile != null)
            {
                _context.BlockedProfile.Remove(blockedProfile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlockedProfileExists(int id)
        {
            return _context.BlockedProfile.Any(e => e.Id == id);
        }
    }
}
