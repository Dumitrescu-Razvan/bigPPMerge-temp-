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
    public class PostsGAMBAsController : Controller
    {
        private readonly IPostGAMBARepository repository;

        public PostsGAMBAsController(IPostGAMBARepository _repository)
        {
            repository = _repository;
        }

        // GET: PostsGAMBAs
        public async Task<IActionResult> Index()
        {
            var posts = await repository.GetPostsAsync();
            return View(posts);
        }

        // GET: PostsGAMBAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postsGAMBA = await repository.GetPostByIdAsync(id.Value);
            if (postsGAMBA == null)
            {
                return NotFound();
            }

            return View(postsGAMBA);
        }

        // GET: PostsGAMBAs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostsGAMBAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Post_Id,Owner_User_Id,Description,Commented_Post_Id,Original_Post_Id,Media_Path,Post_Type,Location_Id,Created_Date")] PostsGAMBA postsGAMBA)
        {
            repository.AddPostAsync(postsGAMBA);
            return View(postsGAMBA);
        }

        // GET: PostsGAMBAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postsGAMBA = await repository.GetPostByIdAsync(id.Value);
            if (postsGAMBA == null)
            {
                return NotFound();
            }
            return View(postsGAMBA);
        }

        // POST: PostsGAMBAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Post_Id,Owner_User_Id,Description,Commented_Post_Id,Original_Post_Id,Media_Path,Post_Type,Location_Id,Created_Date")] PostsGAMBA postsGAMBA)
        {
            if (id != postsGAMBA.Post_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdatePostAsync(postsGAMBA);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = await repository.PostExistsAsync(postsGAMBA.Post_Id);
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
            return View(postsGAMBA);
        }

        // GET: PostsGAMBAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postsGAMBA = await repository.GetPostByIdAsync(id.Value);
            if (postsGAMBA == null)
            {
                return NotFound();
            }

            return View(postsGAMBA);
        }

        // POST: PostsGAMBAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await repository.DeletePostAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
