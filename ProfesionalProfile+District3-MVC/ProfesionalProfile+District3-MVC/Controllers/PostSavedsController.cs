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
    public class PostavedsController : Controller
    {
        private readonly IPostavedsRepository repository;

        public PostavedsController(IPostavedsRepository PostavedRepository)
        {
            repository = PostavedRepository;
        }

        // GET: Postaveds
        public async Task<IActionResult> Index()
        {
            var Postaved = await repository.GetPostavedAsync();
            return View(Postaved);
        }

        // GET: Postaveds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Postaved = await repository.GetPostavedByIdAsync(id.Value);
            if (Postaved == null)
            {
                return NotFound();
            }

            return View(Postaved);
        }

        // GET: Postaveds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Postaveds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("save_id,post_id,user_id")] Postaved Postaved)
        {
            await repository.AddPostavedAsync(Postaved);
            return View(Postaved);
        }

        // GET: Postaveds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Postaved = await repository.GetPostavedByIdAsync(id.Value);
            if (Postaved == null)
            {
                return NotFound();
            }
            return View(Postaved);
        }

        // POST: Postaveds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("save_id,post_id,user_id")] Postaved Postaved)
        {
            if (id != Postaved.save_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdatePostavedAsync(Postaved);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = await repository.PostavedExistsAsync(Postaved.save_id);
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
            return View(Postaved);
        }

        // GET: Postaveds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Postaved = await repository.GetPostavedByIdAsync(id.Value);
            if (Postaved == null)
            {
                return NotFound();
            }

            return View(Postaved);
        }

        // POST: Postaveds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await repository.DeletePostavedAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
