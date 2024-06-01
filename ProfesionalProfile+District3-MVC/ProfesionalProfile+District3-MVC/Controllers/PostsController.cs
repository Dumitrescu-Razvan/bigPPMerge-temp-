﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Repositories;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class PostsController : Controller
    {
         private readonly IRepoInterface<Post> postRepository;

        public PostsController(IRepoInterface<Post> psRepo)
        {
            postRepository = psRepo;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            ///return View(await _context.Post.ToListAsync());
            var posts = postRepository.GetAll();
            return View(posts);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int idValue = id.Value;
            var post = postRepository.GetById(idValue);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Post post)
        {
            if (ModelState.IsValid)
            {
                /*
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                */
                postRepository.Add(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var post = await _context.Post.FindAsync(id);
            var post = postRepository.GetById(id.Value);

            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                    */
                    postRepository.Update(post);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
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
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           // var post = await _context.Post
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var post = postRepository.GetById(id.Value);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ///var post = await _context.Post.FindAsync(id);
           var post = postRepository.GetById(id);
            if (post != null)
            {
                ///_context.Post.Remove(post);
                postRepository.Delete(post.Id);
            }

            ///await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            ///return _context.Post.Any(e => e.Id == id);
            var post = postRepository.GetById(id);
            if (post != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
