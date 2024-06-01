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
    public class FollowsController : Controller
    {
        private readonly IFollowsRepository repository;

        public FollowsController(IFollowsRepository repository)
        {
            this.repository = repository;
        }

        // GET: Follows
        public async Task<IActionResult> Index()
        {
            var follows = await repository.GetFollowsAsync();
            return View(follows);
        }

        // GET: Follows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var follow = await repository.GetFollowByIdAsync(id.Value);
            if (follow == null)
            {
                return NotFound();
            }

            return View(follow);
        }

        // GET: Follows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Follows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,sender,receiver,isCloseFriend,expirationTimeStamp,description")] Follow follow)
        {
            await repository.AddFollowAsync(follow);
            return View(follow);
        }

        // GET: Follows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var follow = await repository.GetFollowByIdAsync(id.Value);
            if (follow == null)
            {
                return NotFound();
            }
            return View(follow);
        }

        // POST: Follows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,sender,receiver,isCloseFriend,expirationTimeStamp,description")] Follow follow)
        {
            if (id != follow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdateFollowAsync(follow);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = await repository.FollowExistsAsync(follow.Id);
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
            return View(follow);
        }

        // GET: Follows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var follow = await repository.GetFollowByIdAsync(id.Value);
            if (follow == null)
            {
                return NotFound();
            }

            return View(follow);
        }

        // POST: Follows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await repository.DeleteFollowAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
