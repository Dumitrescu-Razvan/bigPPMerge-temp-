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
    public class PostSavedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostSavedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostSaveds
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostSaved.ToListAsync());
        }

        // GET: PostSaveds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postSaved = await _context.PostSaved
                .FirstOrDefaultAsync(m => m.save_id == id);
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
            if (ModelState.IsValid)
            {
                _context.Add(postSaved);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postSaved);
        }

        // GET: PostSaveds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postSaved = await _context.PostSaved.FindAsync(id);
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
                    _context.Update(postSaved);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostSavedExists(postSaved.save_id))
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

            var postSaved = await _context.PostSaved
                .FirstOrDefaultAsync(m => m.save_id == id);
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
            var postSaved = await _context.PostSaved.FindAsync(id);
            if (postSaved != null)
            {
                _context.PostSaved.Remove(postSaved);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostSavedExists(int id)
        {
            return _context.PostSaved.Any(e => e.save_id == id);
        }
    }
}
