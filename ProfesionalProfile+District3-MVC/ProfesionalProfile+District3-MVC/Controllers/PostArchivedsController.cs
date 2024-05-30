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
    public class PostArchivedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostArchivedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostArchiveds
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostArchived.ToListAsync());
        }

        // GET: PostArchiveds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postArchived = await _context.PostArchived
                .FirstOrDefaultAsync(m => m.post_id == id);
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
            if (ModelState.IsValid)
            {
                _context.Add(postArchived);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postArchived);
        }

        // GET: PostArchiveds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postArchived = await _context.PostArchived.FindAsync(id);
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
                    _context.Update(postArchived);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostArchivedExists(postArchived.post_id))
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

            var postArchived = await _context.PostArchived
                .FirstOrDefaultAsync(m => m.post_id == id);
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
            var postArchived = await _context.PostArchived.FindAsync(id);
            if (postArchived != null)
            {
                _context.PostArchived.Remove(postArchived);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostArchivedExists(int id)
        {
            return _context.PostArchived.Any(e => e.post_id == id);
        }
    }
}
