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
    public class FancierProfilesController : Controller
    {
        private readonly IRepoInterface<FancierProfile> fancierProfileRepository;
        private readonly IUserRepo userRepository;

        public FancierProfilesController(IRepoInterface<FancierProfile> fpRepo, IUserRepo usRepo)
        {
            fancierProfileRepository = fpRepo;
            userRepository = usRepo;
        }

        // GET: FancierProfiles
        public async Task<IActionResult> Index()
        {
            //return View(await _context.FancierProfile.ToListAsync());
            var fancierProfiles = fancierProfileRepository.GetAll();
            return View(fancierProfiles);
        }

        // GET: FancierProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           /* var fancierProfile = await _context.FancierProfile
                .FirstOrDefaultAsync(m => m.ProfileId == id);*/
           var fancierProfile = fancierProfileRepository.GetById(id.Value);
            if (fancierProfile == null)
            {
                return NotFound();
            }

            return View(fancierProfile);
        }

        // GET: FancierProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FancierProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfileId,Links,DailyMotto,RemoveMottoDate,FrameNumber,Hashtag")] FancierProfile fancierProfile)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(fancierProfile);
                await _context.SaveChangesAsync();*/
                fancierProfileRepository.Add(fancierProfile);
                return RedirectToAction(nameof(Index));
            }
            return View(fancierProfile);
        }

        // GET: FancierProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var fancierProfile = await _context.FancierProfile.FindAsync(id);
            var fancierProfile = fancierProfileRepository.GetById(id.Value);
            if (fancierProfile == null)
            {
                return NotFound();
            }
            return View(fancierProfile);
        }

        // POST: FancierProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfileId,Links,DailyMotto,RemoveMottoDate,FrameNumber,Hashtag")] FancierProfile fancierProfile)
        {
            if (id != fancierProfile.ProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*
                    _context.Update(fancierProfile);
                    await _context.SaveChangesAsync();
                    */
                    fancierProfileRepository.Update(fancierProfile);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FancierProfileExists(fancierProfile.ProfileId))
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
            return View(fancierProfile);
        }

        // GET: FancierProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var fancierProfile = await _context.FancierProfile
                .FirstOrDefaultAsync(m => m.ProfileId == id);*/
            var fancierProfile = fancierProfileRepository.GetById(id.Value);
            if (fancierProfile == null)
            {
                return NotFound();
            }

            return View(fancierProfile);
        }

        // POST: FancierProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var fancierProfile = await _context.FancierProfile.FindAsync(id);
            var fancierProfile = fancierProfileRepository.GetById(id);
            if (fancierProfile != null)
            {
                //_context.FancierProfile.Remove(fancierProfile);
                fancierProfileRepository.Delete(fancierProfile.ProfileId);
            }

            //await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool FancierProfileExists(int id)
        {
            //return _context.FancierProfile.Any(e => e.ProfileId == id);
            var result = fancierProfileRepository.GetById(id);
            if (result != null)
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
