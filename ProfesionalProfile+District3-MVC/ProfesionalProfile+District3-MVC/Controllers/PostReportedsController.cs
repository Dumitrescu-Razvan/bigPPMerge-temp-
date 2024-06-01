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
    public class PostReportedsController : Controller
    {
        private readonly IPostReportedRepository repository;

        public PostReportedsController(IPostReportedRepository postReportedRepository)
        {
            repository = postReportedRepository;
        }


        // GET: PostReporteds
        public async Task<IActionResult> Index()
        {
            var postReported = await repository.GetPostReportedAsync();
            return View(postReported);
        }

        // GET: PostReporteds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postReported = await repository.GetPostReportedByIdAsync(id.Value);
            if (postReported == null)
            {
                return NotFound();
            }

            return View(postReported);
        }

        // GET: PostReporteds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostReporteds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Report_Id,Reason,Description,Post_Id,Reporter_Id")] PostReported postReported)
        {
            await repository.AddPostReportedAsync(postReported);
            return View(postReported);
        }

        // GET: PostReporteds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postReported = await repository.GetPostReportedByIdAsync(id.Value);
            if (postReported == null)
            {
                return NotFound();
            }
            return View(postReported);
        }

        // POST: PostReporteds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Report_Id,Reason,Description,Post_Id,Reporter_Id")] PostReported postReported)
        {
            if (id != postReported.Report_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  await repository.UpdatePostReportedAsync(postReported);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = await repository.PostReportedExistsAsync(postReported.Report_Id);
                    if (exists)
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
            return View(postReported);
        }

        // GET: PostReporteds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postReported = await repository.GetPostReportedByIdAsync(id.Value);
            if (postReported == null)
            {
                return NotFound();
            }

            return View(postReported);
        }

        // POST: PostReporteds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await repository.DeletePostReportedAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
