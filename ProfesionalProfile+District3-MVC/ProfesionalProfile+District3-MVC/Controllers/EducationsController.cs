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
    public class EducationsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IEducationRepo _educationRepo;
        private readonly IUserRepo _userRepo;


        public EducationsController(IEducationRepo educationRepo, IUserRepo userRepo)
        {
            _educationRepo = educationRepo;
            _userRepo = userRepo;
        }

        // GET: Educations
        public async Task<IActionResult> Index()
        {
            var educations = _educationRepo.GetAll();
            return View(educations);
            //var applicationDbContext = _context.Educations.Include(e => e.User);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Educations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = _educationRepo.GetById(id.Value);
            /*var education = await _context.Educations
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.educationId == id);*/
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // GET: Educations/Create
        public IActionResult Create()
        {
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId");
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId");
            return View();
        }

        // POST: Educations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("educationId,userId,degree,institution,fieldOfStudy,graduationDate")] Education education)
        {
            ModelState.Remove("User");
            
            if (ModelState.IsValid)
            {
                _educationRepo.Add(education);
                //_context.Add(education);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", education.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", education.userId);
            return View(education);
        }

        // GET: Educations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = _educationRepo.GetById(id.Value);
            //var education = await _context.Educations.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", education.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", education.userId);
            return View(education);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("educationId,userId,degree,institution,fieldOfStudy,graduationDate")] Education education)
        {
            if (id != education.educationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _educationRepo.Update(education);
                    //_context.Update(education);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationExists(education.educationId))
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
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", education.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", education.userId);
            return View(education);
        }

        // GET: Educations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = _educationRepo.GetById(id.Value);
            //var education = await _context.Educations
            //    .Include(e => e.User)
            //    .FirstOrDefaultAsync(m => m.educationId == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = _educationRepo.GetById(id);
            //var education = await _context.Educations.FindAsync(id);
            if (education != null)
            {
                _educationRepo.Delete(id);
                //_context.Educations.Remove(education);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationExists(int id)
        {
            return _educationRepo.GetById(id) != null;
            //return _context.Educations.Any(e => e.educationId == id);
        }
    }
}
