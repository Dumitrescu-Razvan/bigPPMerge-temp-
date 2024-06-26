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
    public class GroupsController : Controller
    {
        private readonly IRepoInterface<Group> groupRepository;
        private readonly IUserRepo userRepository;

        public GroupsController(IRepoInterface<Group> groRepo, IUserRepo usRepo)
        {
            groupRepository = groRepo;
            userRepository = usRepo;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Group.ToListAsync());
            return View(groupRepository.GetAll());
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var @group = await _context.Group
                .FirstOrDefaultAsync(m => m.Id == id);*/
            var @group = groupRepository.GetById(id.Value);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupName")] Group @group)
        {
            if (ModelState.IsValid)
            {
                /*
                _context.Add(@group);
                await _context.SaveChangesAsync();*/
                groupRepository.Add(@group);
                return RedirectToAction(nameof(Index));
            }
            return View(@group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var @group = await _context.Group.FindAsync(id);
            var @group = groupRepository.GetById(id.Value);
            if (@group == null)
            {
                return NotFound();
            }
            return View(@group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupName")] Group @group)
        {
            if (id != @group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*
                    _context.Update(@group);
                    await _context.SaveChangesAsync();*/
                    groupRepository.Update(@group);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.Id))
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
            return View(@group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var @group = await _context.Group
                .FirstOrDefaultAsync(m => m.Id == id);*/
            var @group = groupRepository.GetById(id.Value);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var @group = await _context.Group.FindAsync(id);
            var @group = groupRepository.GetById(id);
            if (@group != null)
            {
                //_context.Group.Remove(@group);
                groupRepository.Delete(@group.Id);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
           // return _context.Group.Any(e => e.Id == id);
          var group = groupRepository.GetById(id);
            return group != null;
        }
    }
}
