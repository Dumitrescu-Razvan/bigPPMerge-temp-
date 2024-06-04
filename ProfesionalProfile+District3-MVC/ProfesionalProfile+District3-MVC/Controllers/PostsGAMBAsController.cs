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
    public class PostGAMBAsController : Controller
    {
        private readonly IPostGAMBARepository repository;

        public PostGAMBAsController(IPostGAMBARepository _repository)
        {
            repository = _repository;
        }

        // GET: PostGAMBAs
        public async Task<IActionResult> Index()
        {
            var Post = await repository.GetPostAsync();
            return View(Post);
        }

        // GET: PostGAMBAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var PostGAMBA = await repository.GetPostByIdAsync(id.Value);
            if (PostGAMBA == null)
            {
                return NotFound();
            }

            return View(PostGAMBA);
        }

        // GET: PostGAMBAs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostGAMBAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Post_Id,Owner_User_Id,Description,Commented_Post_Id,Original_Post_Id,Media_Path,Post_Type,Location_Id,Created_Date")] PostGAMBA PostGAMBA)
        {
            repository.AddPostAsync(PostGAMBA);
            return View(PostGAMBA);
        }

        // GET: PostGAMBAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var PostGAMBA = await repository.GetPostByIdAsync(id.Value);
            if (PostGAMBA == null)
            {
                return NotFound();
            }
            return View(PostGAMBA);
        }

        // POST: PostGAMBAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Post_Id,Owner_User_Id,Description,Commented_Post_Id,Original_Post_Id,Media_Path,Post_Type,Location_Id,Created_Date")] PostGAMBA PostGAMBA)
        {
            if (id != PostGAMBA.Post_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdatePostAsync(PostGAMBA);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = await repository.PostExistsAsync(PostGAMBA.Post_Id);
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
            return View(PostGAMBA);
        }

        // GET: PostGAMBAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var PostGAMBA = await repository.GetPostByIdAsync(id.Value);
            if (PostGAMBA == null)
            {
                return NotFound();
            }

            return View(PostGAMBA);
        }

        // POST: PostGAMBAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await repository.DeletePostAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
