using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Repositories;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class BlockedProfilesController : Controller
    {
        private BlockedProfileRepository blockedProfileRepository;
        private UserRepository userRepository;

        public BlockedProfilesController(ApplicationDbContext context)
        {
            blockedProfileRepository = new BlockedProfileRepository(context);
            userRepository = new UserRepository(context);
        }

        // GET: BlockedProfiles
        public async Task<IActionResult> Index()
        {
            /*
            var applicationDbContext = _context.BlockedProfile.Include(b => b.User);
            return View(await applicationDbContext.ToListAsync());*/
            return View(blockedProfileRepository.GetAll());
        }

        // GET: BlockedProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            /*
            var blockedProfile = await _context.BlockedProfile
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            var blockedProfile = blockedProfileRepository.GetById(id.Value);
            if (blockedProfile == null)
            {
                return NotFound();
            }

            return View(blockedProfile);
        }

        // GET: BlockedProfiles/Create
        public IActionResult Create()
        {
            /*
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");*/
            ViewData["UserId"] = new SelectList(userRepository.GetAll(), "Id", "Id");
            return View();
        }

        // POST: BlockedProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,BlockDate")] BlockedProfile blockedProfile)
        {
            if (ModelState.IsValid)
            {
                /*
                _context.Add(blockedProfile);
                await _context.SaveChangesAsync();*/
                blockedProfileRepository.Add(blockedProfile);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", blockedProfile.UserId);
            ViewData["UserId"] = new SelectList(userRepository.GetAll(), "Id", "Id", blockedProfile.UserId);
            return View(blockedProfile);
        }

        // GET: BlockedProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var blockedProfile = await _context.BlockedProfile.FindAsync(id);
            var blockedProfile = blockedProfileRepository.GetById(id.Value);
            if (blockedProfile == null)
            {
                return NotFound();
            }
            //ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", blockedProfile.UserId);
            ViewData["UserId"] = new SelectList(userRepository.GetAll(), "Id", "Id", blockedProfile.UserId);
            return View(blockedProfile);
        }

        // POST: BlockedProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,BlockDate")] BlockedProfile blockedProfile)
        {
            if (id != blockedProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*
                    _context.Update(blockedProfile);
                    await _context.SaveChangesAsync();*/
                    blockedProfileRepository.Update(blockedProfile);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlockedProfileExists(blockedProfile.Id))
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
            //ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", blockedProfile.UserId);
            ViewData["UserId"] = new SelectList(userRepository.GetAll(), "Id", "Id", blockedProfile.UserId);
            return View(blockedProfile);
        }

        // GET: BlockedProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            /*
            var blockedProfile = await _context.BlockedProfile
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            var blockedProfile = blockedProfileRepository.GetById(id.Value);
            if (blockedProfile == null)
            {
                return NotFound();
            }

            return View(blockedProfile);
        }

        // POST: BlockedProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var blockedProfile = await _context.BlockedProfile.FindAsync(id);
            var blockedProfile = blockedProfileRepository.GetById(id);
            if (blockedProfile != null)
            {
                //_context.BlockedProfile.Remove(blockedProfile);
                blockedProfileRepository.Delete(blockedProfile.Id);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlockedProfileExists(int id)
        {
            //return _context.BlockedProfile.Any(e => e.Id == id);
            var blockedProfile = blockedProfileRepository.GetById(id);
            if (blockedProfile != null)
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
