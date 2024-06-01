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
    public class PostArchivedsController : Controller
    {
        private readonly IPostArchivedRepository repository;

        public PostArchivedsController(IPostArchivedRepository postArchivedRepository)
        {
            repository = postArchivedRepository;
        }

        // GET: PostArchiveds
        public async Task<IActionResult> Index()
        {
            var postArchivedList = await repository.GetPostArchivedAsync();
            return View(postArchivedList);
        }

        // GET: PostArchiveds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postArchived = await repository.GetPostArchivedByIdAsync(id.Value);
            if (postArchived == null)
            {
                return NotFound();
            }

            return View(postArchived);
        }

        // GET: PostArchiveds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostArchiveds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("post_id,archive_id")] PostArchived postArchived)
        {
            await repository.AddPostArchivedAsync(postArchived);
            return View(postArchived);
        }

        // GET: PostArchiveds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postArchived = await repository.GetPostArchivedByIdAsync(id.Value);
            if (postArchived == null)
            {
                return NotFound();
            }
            return View(postArchived);
        }

        // POST: PostArchiveds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("post_id,archive_id")] PostArchived postArchived)
        {
            if (id != postArchived.post_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  await repository.UpdatePostArchivedAsync(postArchived);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = await repository.PostArchivedExistsAsync(id);
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
            return View(postArchived);
        }

        // GET: PostArchiveds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postArchived = await repository.GetPostArchivedByIdAsync(id.Value);
            if (postArchived == null)
            {
                return NotFound();
            }

            return View(postArchived);
        }

        // POST: PostArchiveds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await repository.DeletePostArchivedAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
