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
    public class FollowedFeedFollowedUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FollowedFeedFollowedUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FollowedFeedFollowedUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.FollowedFeedFollowedUsers.ToListAsync());
        }

        // GET: FollowedFeedFollowedUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followedFeedFollowedUsers = await _context.FollowedFeedFollowedUsers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (followedFeedFollowedUsers == null)
            {
                return NotFound();
            }

            return View(followedFeedFollowedUsers);
        }

        // GET: FollowedFeedFollowedUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FollowedFeedFollowedUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FollowedFeedID,FollowedUserID")] FollowedFeedFollowedUsers followedFeedFollowedUsers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(followedFeedFollowedUsers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(followedFeedFollowedUsers);
        }

        // GET: FollowedFeedFollowedUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followedFeedFollowedUsers = await _context.FollowedFeedFollowedUsers.FindAsync(id);
            if (followedFeedFollowedUsers == null)
            {
                return NotFound();
            }
            return View(followedFeedFollowedUsers);
        }

        // POST: FollowedFeedFollowedUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FollowedFeedID,FollowedUserID")] FollowedFeedFollowedUsers followedFeedFollowedUsers)
        {
            if (id != followedFeedFollowedUsers.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(followedFeedFollowedUsers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FollowedFeedFollowedUsersExists(followedFeedFollowedUsers.ID))
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
            return View(followedFeedFollowedUsers);
        }

        // GET: FollowedFeedFollowedUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followedFeedFollowedUsers = await _context.FollowedFeedFollowedUsers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (followedFeedFollowedUsers == null)
            {
                return NotFound();
            }

            return View(followedFeedFollowedUsers);
        }

        // POST: FollowedFeedFollowedUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var followedFeedFollowedUsers = await _context.FollowedFeedFollowedUsers.FindAsync(id);
            if (followedFeedFollowedUsers != null)
            {
                _context.FollowedFeedFollowedUsers.Remove(followedFeedFollowedUsers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FollowedFeedFollowedUsersExists(int id)
        {
            return _context.FollowedFeedFollowedUsers.Any(e => e.ID == id);
        }
    }
}
