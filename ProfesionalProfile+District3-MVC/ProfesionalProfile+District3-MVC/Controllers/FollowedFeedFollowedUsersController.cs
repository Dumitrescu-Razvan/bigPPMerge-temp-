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
    public class FollowedFeedFollowedUsersController : Controller
    {
        private readonly IFollowedFeedFollowedUsersRepository repository;

        public FollowedFeedFollowedUsersController(IFollowedFeedFollowedUsersRepository repository)
        {
            this.repository = repository;
        }

        // GET: FollowedFeedFollowedUsers
        public async Task<IActionResult> Index()
        {
            var followedFeedFollowedUsers = await repository.GetFollowedFeedFollowedUsersAsync();
            return View(followedFeedFollowedUsers);
        }

        // GET: FollowedFeedFollowedUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followedFeedFollowedUsers = await repository.GetFollowedFeedFollowedUsersByIdAsync(id.Value);
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
                await repository.AddFollowedFeedFollowedUsersAsync(followedFeedFollowedUsers);
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

            var followedFeedFollowedUsers = await repository.GetFollowedFeedFollowedUsersByIdAsync(id.Value);
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
                   await repository.UpdateFollowedFeedFollowedUsersAsync(followedFeedFollowedUsers);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = await repository.FollowedFeedFollowedUsersExistsAsync(id);
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
            return View(followedFeedFollowedUsers);
        }

        // GET: FollowedFeedFollowedUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followedFeedFollowedUsers = await repository.GetFollowedFeedFollowedUsersByIdAsync(id.Value);
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
            await repository.DeleteFollowedFeedFollowedUsersAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
