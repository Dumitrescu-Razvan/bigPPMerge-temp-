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
    public class PostSavedsController : Controller
    {
        private readonly IPostSavedsRepository repository;

        public PostSavedsController(IPostSavedsRepository postSavedRepository)
        {
            repository = postSavedRepository;
        }

        // GET: PostSaveds
        public async Task<IActionResult> Index()
        {
            var postSaved = await repository.GetPostSavedAsync();
            return View(postSaved);
        }

        // GET: PostSaveds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postSaved = await repository.GetPostSavedByIdAsync(id.Value);
            if (postSaved == null)
            {
                return NotFound();
            }

            return View(postSaved);
        }

        // GET: PostSaveds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostSaveds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("save_id,post_id,user_id")] PostSaved postSaved)
        {
            await repository.AddPostSavedAsync(postSaved);
            return View(postSaved);
        }

        // GET: PostSaveds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postSaved = await repository.GetPostSavedByIdAsync(id.Value);
            if (postSaved == null)
            {
                return NotFound();
            }
            return View(postSaved);
        }

        // POST: PostSaveds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("save_id,post_id,user_id")] PostSaved postSaved)
        {
            if (id != postSaved.save_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdatePostSavedAsync(postSaved);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = await repository.PostSavedExistsAsync(postSaved.save_id);
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
            return View(postSaved);
        }

        // GET: PostSaveds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postSaved = await repository.GetPostSavedByIdAsync(id.Value);
            if (postSaved == null)
            {
                return NotFound();
            }

            return View(postSaved);
        }

        // POST: PostSaveds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await repository.DeletePostSavedAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
