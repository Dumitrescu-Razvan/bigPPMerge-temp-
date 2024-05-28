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
    public class EndorsementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EndorsementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Endorsements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Endorsements.Include(e => e.Endorser).Include(e => e.Recipient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Endorsements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endorsement = await _context.Endorsements
                .Include(e => e.Endorser)
                .Include(e => e.Recipient)
                .FirstOrDefaultAsync(m => m.endorsementId == id);
            if (endorsement == null)
            {
                return NotFound();
            }

            return View(endorsement);
        }

        // GET: Endorsements/Create
        public IActionResult Create()
        {
            ViewData["endorserId"] = new SelectList(_context.Users, "userId", "userId");
            ViewData["recipientid"] = new SelectList(_context.Users, "userId", "userId");
            return View();
        }

        // POST: Endorsements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("endorsementId,endorserId,recipientid,skillId")] Endorsement endorsement)
        {   
            ModelState.Remove("Endorser");
            ModelState.Remove("Recipient");
            if (ModelState.IsValid)
            {
                _context.Add(endorsement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["endorserId"] = new SelectList(_context.Users, "userId", "userId", endorsement.endorserId);
            ViewData["recipientid"] = new SelectList(_context.Users, "userId", "userId", endorsement.recipientid);
            return View(endorsement);
        }

        // GET: Endorsements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endorsement = await _context.Endorsements.FindAsync(id);
            if (endorsement == null)
            {
                return NotFound();
            }
            ViewData["endorserId"] = new SelectList(_context.Users, "userId", "userId", endorsement.endorserId);
            ViewData["recipientid"] = new SelectList(_context.Users, "userId", "userId", endorsement.recipientid);
            return View(endorsement);
        }

        // POST: Endorsements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("endorsementId,endorserId,recipientid,skillId")] Endorsement endorsement)
        {
            if (id != endorsement.endorsementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endorsement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EndorsementExists(endorsement.endorsementId))
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
            ViewData["endorserId"] = new SelectList(_context.Users, "userId", "userId", endorsement.endorserId);
            ViewData["recipientid"] = new SelectList(_context.Users, "userId", "userId", endorsement.recipientid);
            return View(endorsement);
        }

        // GET: Endorsements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endorsement = await _context.Endorsements
                .Include(e => e.Endorser)
                .Include(e => e.Recipient)
                .FirstOrDefaultAsync(m => m.endorsementId == id);
            if (endorsement == null)
            {
                return NotFound();
            }

            return View(endorsement);
        }

        // POST: Endorsements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var endorsement = await _context.Endorsements.FindAsync(id);
            if (endorsement != null)
            {
                _context.Endorsements.Remove(endorsement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EndorsementExists(int id)
        {
            return _context.Endorsements.Any(e => e.endorsementId == id);
        }
    }
}
