using System;
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
    public class SkillsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly ISkillRepo _skillRepo;

        public SkillsController(ISkillRepo skillRepo)
        {
            _skillRepo = skillRepo;
        }

        // GET: Skills
        public async Task<IActionResult> Index()
        {
            return View(_skillRepo.GetAll());
            //return View(await _context.Skills.ToListAsync());
        }

        // GET: Skills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = _skillRepo.GetById(id.Value);
            /*var skill = await _context.Skills
                .FirstOrDefaultAsync(m => m.skillId == id);*/
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // GET: Skills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("skillId,name")] Skill skill)
        {   
            ModelState.Remove("endorsements");
            if (ModelState.IsValid)
            {
                _skillRepo.Add(skill);
                /*_context.Add(skill);
                await _context.SaveChangesAsync();*/
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: Skills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = _skillRepo.GetById(id.Value);
            //var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("skillId,name")] Skill skill)
        {
            if (id != skill.skillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _skillRepo.Update(skill);
                    /*_context.Update(skill);
                    await _context.SaveChangesAsync();*/
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(skill.skillId))
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
            return View(skill);
        }

        // GET: Skills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = _skillRepo.GetById(id.Value);
            /*var skill = await _context.Skills
                .FirstOrDefaultAsync(m => m.skillId == id);*/
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skill = _skillRepo.GetById(id);
            /*var skill = await _context.Skills.FindAsync(id);*/
            if (skill != null)
            {
                _skillRepo.Delete(id);
                //_context.Skills.Remove(skill);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(int id)
        {
            return _skillRepo.GetAll().Any(e => e.skillId == id);
            //return _context.Skills.Any(e => e.skillId == id);
        }
    }
}
