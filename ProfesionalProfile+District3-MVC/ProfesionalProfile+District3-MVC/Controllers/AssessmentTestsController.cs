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
    public class AssessmentTestsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IAssessmentTestRepo _assessmentTestRepo;
        private readonly ISkillRepo _skillRepo;
        private readonly IUserRepo _userRepo;

        public AssessmentTestsController(IAssessmentTestRepo assessmentTestRepo, ISkillRepo skillRepo, IUserRepo userRepo)
        {
            _skillRepo = skillRepo;
            _userRepo = userRepo;
            _assessmentTestRepo = assessmentTestRepo;
        }

        // GET: AssessmentTests
        public async Task<IActionResult> Index()
        {
            return View(_assessmentTestRepo.GetAll());
            //var applicationDbContext = _context.AssessmentTests.Include(a => a.Skill).Include(a => a.User);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: AssessmentTests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessmentTest = _assessmentTestRepo.GetById(id.Value);
            /*var assessmentTest = await _context.AssessmentTests
                .Include(a => a.Skill)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.assessmentTestId == id);*/
            if (assessmentTest == null)
            {
                return NotFound();
            }

            return View(assessmentTest);
        }

        // GET: AssessmentTests/Create
        public IActionResult Create()
        {
            ViewData["skillid"] = new SelectList(_skillRepo.GetAll(), "skillId", "skillId");
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId");
            //ViewData["skillid"] = new SelectList(_context.Skills, "skillId", "skillId");
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId");
            return View();
        }

        // POST: AssessmentTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("assessmentTestId,testName,userId,description,skillid")] AssessmentTest assessmentTest)
        {   

            ModelState.Remove("User");
            ModelState.Remove("Skill");
            ModelState.Remove("AssessmentResult");
            
            if (ModelState.IsValid)
            {
                _assessmentTestRepo.Add(assessmentTest);
             /*   _context.Add(assessmentTest);
                await _context.SaveChangesAsync();*/
                return RedirectToAction(nameof(Index));
            }
            ViewData["skillid"] = new SelectList(_skillRepo.GetAll(), "skillId", "skillId", assessmentTest.skillid);
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", assessmentTest.userId);
            //ViewData["skillid"] = new SelectList(_context.Skills, "skillId", "skillId", assessmentTest.skillid);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", assessmentTest.userId);
            return View(assessmentTest);
        }

        // GET: AssessmentTests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessmentTest = _assessmentTestRepo.GetById(id.Value);
            //var assessmentTest = await _context.AssessmentTests.FindAsync(id);
            if (assessmentTest == null)
            {
                return NotFound();
            }
            ViewData["skillid"] = new SelectList(_skillRepo.GetAll(), "skillId", "skillId", assessmentTest.skillid);
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", assessmentTest.userId);
            //ViewData["skillid"] = new SelectList(_context.Skills, "skillId", "skillId", assessmentTest.skillid);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", assessmentTest.userId);
            return View(assessmentTest);
        }

        // POST: AssessmentTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("assessmentTestId,testName,userId,description,skillid")] AssessmentTest assessmentTest)
        {
            if (id != assessmentTest.assessmentTestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _assessmentTestRepo.Update(assessmentTest);
                    /*_context.Update(assessmentTest);
                    await _context.SaveChangesAsync();*/
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssessmentTestExists(assessmentTest.assessmentTestId))
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
            ViewData["skillid"] = new SelectList(_skillRepo.GetAll(), "skillId", "skillId", assessmentTest.skillid);
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", assessmentTest.userId);
            //ViewData["skillid"] = new SelectList(_context.Skills, "skillId", "skillId", assessmentTest.skillid);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", assessmentTest.userId);
            return View(assessmentTest);
        }

        // GET: AssessmentTests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var assessmentTest = _assessmentTestRepo.GetById(id.Value);
            //var assessmentTest = await _context.AssessmentTests
            /*    .Include(a => a.Skill)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.assessmentTestId == id);*/
            if (assessmentTest == null)
            {
                return NotFound();
            }

            return View(assessmentTest);
        }

        // POST: AssessmentTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assessmentTest = _assessmentTestRepo.GetById(id);
            //var assessmentTest = await _context.AssessmentTests.FindAsync(id);
            if (assessmentTest != null)
            {
                _assessmentTestRepo.Delete(assessmentTest.assessmentTestId);
                //_context.AssessmentTests.Remove(assessmentTest);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssessmentTestExists(int id)
        {
            return _assessmentTestRepo.GetAll().Any(e => e.assessmentTestId == id);
            //return _context.AssessmentTests.Any(e => e.assessmentTestId == id);
        }
    }
}
