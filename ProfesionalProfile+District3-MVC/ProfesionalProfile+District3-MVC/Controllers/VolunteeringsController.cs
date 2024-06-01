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
    public class VolunteeringsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IVolunteeringRepo _volunteeringRepo;
        private readonly IUserRepo _userRepo;

        public VolunteeringsController(IVolunteeringRepo volunteeringRepo, IUserRepo userRepo)
        {
            _volunteeringRepo = volunteeringRepo;
            _userRepo = userRepo;
        }

        // GET: Volunteerings
        public async Task<IActionResult> Index()
        {
            return View(_volunteeringRepo.GetAll());
            //var applicationDbContext = _context.Volunteerings.Include(v => v.User);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Volunteerings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var volunteering = _volunteeringRepo.GetById(id.Value);
            /*var volunteering = await _context.Volunteerings
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.volunteeringId == id);*/
            if (volunteering == null)
            {
                return NotFound();
            }

            return View(volunteering);
        }

        // GET: Volunteerings/Create
        public IActionResult Create()
        {
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId");
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId");
            return View();
        }

        // POST: Volunteerings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("volunteeringId,userId,organisation,role,description")] Volunteering volunteering)
        {   
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                _volunteeringRepo.Add(volunteering);
                /*_context.Add(volunteering);
                await _context.SaveChangesAsync();*/
                return RedirectToAction(nameof(Index));
            }
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", volunteering.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", volunteering.userId);
            return View(volunteering);
        }

        // GET: Volunteerings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteering = _volunteeringRepo.GetById(id.Value);
            //var volunteering = await _context.Volunteerings.FindAsync(id);
            if (volunteering == null)
            {
                return NotFound();
            }
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", volunteering.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", volunteering.userId);
            return View(volunteering);
        }

        // POST: Volunteerings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("volunteeringId,userId,organisation,role,description")] Volunteering volunteering)
        {
            if (id != volunteering.volunteeringId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _volunteeringRepo.Update(volunteering);
                    //_context.Update(volunteering);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolunteeringExists(volunteering.volunteeringId))
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
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", volunteering.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", volunteering.userId);
            return View(volunteering);
        }

        // GET: Volunteerings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteering = _volunteeringRepo.GetById(id.Value);
            /*var volunteering = await _context.Volunteerings
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.volunteeringId == id);*/
            if (volunteering == null)
            {
                return NotFound();
            }

            return View(volunteering);
        }

        // POST: Volunteerings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volunteering = _volunteeringRepo.GetById(id);
            //var volunteering = await _context.Volunteerings.FindAsync(id);
            if (volunteering != null)
            {
                _volunteeringRepo.Delete(id);
                //_context.Volunteerings.Remove(volunteering);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VolunteeringExists(int id)
        {
            return _volunteeringRepo.GetAll().Any(e => e.volunteeringId == id);
            //return _context.Volunteerings.Any(e => e.volunteeringId == id);
        }
    }
}
