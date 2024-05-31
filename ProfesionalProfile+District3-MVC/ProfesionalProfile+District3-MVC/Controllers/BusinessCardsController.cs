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
using ProfesionalProfile_District3_MVC.Repositories;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class BusinessCardsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IBusinessCardRepo _businessCardRepo;
        private readonly IUserRepo _userRepo;

        public BusinessCardsController(IBusinessCardRepo businessCardRepo, IUserRepo userRepo)
        {
            _businessCardRepo = businessCardRepo;
            _userRepo = userRepo;
        }

        // GET: BusinessCards
        public async Task<IActionResult> Index()
        {
            var businessCards = _businessCardRepo.GetAll();
            return View(businessCards);
            //var applicationDbContext = _context.BusinessCards.Include(b => b.User);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: BusinessCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bussinesCard = _businessCardRepo.GetById(id.Value);
            /*var bussinesCard = await _context.BusinessCards
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.bcId == id);*/
            if (bussinesCard == null)
            {
                return NotFound();
            }

            return View(bussinesCard);
        }

        // GET: BusinessCards/Create
        public IActionResult Create()
        {
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId");
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId");
            return View();
        }

        // POST: BusinessCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bcId,userId,summary,uniqueUrl")] BusinessCard bussinesCard)
        {
            ModelState.Remove("User");
            ModelState.Remove("keySkills");
            
            if (ModelState.IsValid)
            {
                _businessCardRepo.Add(bussinesCard);
                /*_context.Add(bussinesCard);
                await _context.SaveChangesAsync();*/
                return RedirectToAction(nameof(Index));
            }
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", bussinesCard.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", bussinesCard.userId);
            return View(bussinesCard);
        }

        // GET: BusinessCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bussinesCard = _businessCardRepo.GetById(id.Value);
            //var bussinesCard = await _context.BusinessCards.FindAsync(id);
            if (bussinesCard == null)
            {
                return NotFound();
            }
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", bussinesCard.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", bussinesCard.userId);
            return View(bussinesCard);
        }

        // POST: BusinessCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bcId,userId,summary,uniqueUrl")] BusinessCard bussinesCard)
        {
            if (id != bussinesCard.bcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _businessCardRepo.Update(bussinesCard);
                    //_context.Update(bussinesCard);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BussinesCardExists(bussinesCard.bcId))
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
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", bussinesCard.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", bussinesCard.userId);
            return View(bussinesCard);
        }

        // GET: BusinessCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bussinesCard = _businessCardRepo.GetById(id.Value);
           /* var bussinesCard = await _context.BusinessCards
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.bcId == id);*/
            if (bussinesCard == null)
            {
                return NotFound();
            }

            return View(bussinesCard);
        }

        // POST: BusinessCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bussinesCard = _businessCardRepo.GetById(id);
            //var bussinesCard = await _context.BusinessCards.FindAsync(id);
            if (bussinesCard != null)
            {
                _businessCardRepo.Delete(bussinesCard.userId);
                //_context.BusinessCards.Remove(bussinesCard);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BussinesCardExists(int id)
        {
            return _businessCardRepo.GetById(id) != null;
            //return _context.BusinessCards.Any(e => e.bcId == id);
        }
    }
}
