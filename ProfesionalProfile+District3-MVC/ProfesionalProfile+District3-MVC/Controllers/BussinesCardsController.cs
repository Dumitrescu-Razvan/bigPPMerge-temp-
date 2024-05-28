using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class BussinesCardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BussinesCardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BussinesCards
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BussinesCards.Include(b => b.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BussinesCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bussinesCard = await _context.BussinesCards
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.bcId == id);
            if (bussinesCard == null)
            {
                return NotFound();
            }

            return View(bussinesCard);
        }

        // GET: BussinesCards/Create
        public IActionResult Create()
        {
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId");
            return View();
        }

        // POST: BussinesCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bcId,userId,summary,uniqueUrl")] BussinesCard bussinesCard)
        {
            ModelState.Remove("User");
            ModelState.Remove("keySkills");
            
            if (ModelState.IsValid)
            {
                _context.Add(bussinesCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", bussinesCard.userId);
            return View(bussinesCard);
        }

        // GET: BussinesCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bussinesCard = await _context.BussinesCards.FindAsync(id);
            if (bussinesCard == null)
            {
                return NotFound();
            }
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", bussinesCard.userId);
            return View(bussinesCard);
        }

        // POST: BussinesCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bcId,userId,summary,uniqueUrl")] BussinesCard bussinesCard)
        {
            if (id != bussinesCard.bcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bussinesCard);
                    await _context.SaveChangesAsync();
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
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", bussinesCard.userId);
            return View(bussinesCard);
        }

        // GET: BussinesCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bussinesCard = await _context.BussinesCards
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.bcId == id);
            if (bussinesCard == null)
            {
                return NotFound();
            }

            return View(bussinesCard);
        }

        // POST: BussinesCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bussinesCard = await _context.BussinesCards.FindAsync(id);
            if (bussinesCard != null)
            {
                _context.BussinesCards.Remove(bussinesCard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BussinesCardExists(int id)
        {
            return _context.BussinesCards.Any(e => e.bcId == id);
        }
    }
}
