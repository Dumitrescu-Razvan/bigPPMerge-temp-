﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class ProjectsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IProjectRepo _projectRepo;
        private readonly IUserRepo _userRepo;

        public ProjectsController(IProjectRepo projectRepo, IUserRepo userRepo)
        {
            _projectRepo = projectRepo;
            _userRepo = userRepo;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(_projectRepo.GetAll());
            //var applicationDbContext = _context.Projects.Include(p => p.User);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _projectRepo.GetById(id.Value);
            /*var project = await _context.Projects
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.projectId == id);*/
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId");
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("projectId,projectName,description,technologies,userId")] Project project)
        {   
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                _projectRepo.Add(project);
                /*_context.Add(project);
                await _context.SaveChangesAsync();*/
                return RedirectToAction(nameof(Index));
            }
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", project.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", project.userId);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _projectRepo.GetById(id.Value);
            //var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", project.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", project.userId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("projectId,projectName,description,technologies,userId")] Project project)
        {
            if (id != project.projectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _projectRepo.Update(project);
                    /*_context.Update(project);
                    await _context.SaveChangesAsync();*/
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.projectId))
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
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", project.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", project.userId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _projectRepo.GetById(id.Value);
            /*var project = await _context.Projects
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.projectId == id);*/
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = _projectRepo.GetById(id);
            //var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _projectRepo.Delete(id);
                //_context.Projects.Remove(project);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _projectRepo.GetAll().Any(e => e.projectId == id);
            //return _context.Projects.Any(e => e.projectId == id);
        }
    }
}
