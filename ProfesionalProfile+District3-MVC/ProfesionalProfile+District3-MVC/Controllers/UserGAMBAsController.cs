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
    public class UserGAMBAsController : Controller
    {
        private readonly IUsersRepositoryGAMBA repository;

        public UserGAMBAsController(IUsersRepositoryGAMBA userRepository)
        {
            repository = userRepository;
        }
        // GET: UserGAMBAs
        public async Task<IActionResult> Index()
        {
            var users = await repository.GetAllUsersAsync();
            return View( users);
        }

        // GET: UserGAMBAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGAMBA = await repository.GetUserByIdAsync(id.Value);
            if (userGAMBA == null)
            {
                return NotFound();
            }

            return View(userGAMBA);
        }

        // GET: UserGAMBAs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserGAMBAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,ProfilePicturePath")] UserGAMBA userGAMBA)
        {
            await repository.CreateUserAsync(userGAMBA);
            return View(userGAMBA);
        }

        // GET: UserGAMBAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGAMBA = await repository.GetUserByIdAsync(id.Value);
            if (userGAMBA == null)
            {
                return NotFound();
            }
            return View(userGAMBA);
        }

        // POST: UserGAMBAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,ProfilePicturePath")] UserGAMBA userGAMBA)
        {
            if (id != userGAMBA.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdateUserAsync(userGAMBA);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = await repository.UserExistsAsync(userGAMBA.Id);
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
            return View(userGAMBA);
        }

        // GET: UserGAMBAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGAMBA = await repository.GetUserByIdAsync(id.Value);
            if (userGAMBA == null)
            {
                return NotFound();
            }

            return View(userGAMBA);
        }

        // POST: UserGAMBAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await repository.DeleteUserAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
