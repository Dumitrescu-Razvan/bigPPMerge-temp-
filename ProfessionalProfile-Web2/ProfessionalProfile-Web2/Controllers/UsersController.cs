﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfessionalProfile_Web2.Data;
using ProfessionalProfile_Web2.Models;

namespace ProfessionalProfile_Web2.Controllers;

public class UsersController : Controller
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Users
    public async Task<IActionResult> Index()
    {
        return View(await _context.Users.ToListAsync());
    }

    // GET: Users/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var user = await _context.Users
            .FirstOrDefaultAsync(m => m.userId == id);
        if (user == null) return NotFound();

        return View(user);
    }

    // GET: Users/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Users/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind(
            "userId,firstName,lastName,email,password,phone,summary,dateOfBirth,darkTheme,address,websiteURL,picture")]
        User user)
    {
        ModelState.Remove("User");
        if (ModelState.IsValid)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            //redirect to login page
            return RedirectToAction("Login", "Home");
        }

        return View(user);
    }

    // GET: Users/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();
        return View(user);
    }

    // POST: Users/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind(
            "userId,firstName,lastName,email,password,phone,summary,dateOfBirth,darkTheme,address,websiteURL,picture")]
        User user)
    {
        if (id != user.userId) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.userId))
                    return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(user);
    }

    // GET: Users/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var user = await _context.Users
            .FirstOrDefaultAsync(m => m.userId == id);
        if (user == null) return NotFound();

        return View(user);
    }

    // POST: Users/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null) _context.Users.Remove(user);

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool UserExists(int id)
    {
        return _context.Users.Any(e => e.userId == id);
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.email == email && u.password == password);

        if (user != null)
            // Login successful
            // Here you can add code to log the user in, like setting a cookie or a session variable
            return RedirectToAction("ProfilePage", "Home");

        // Login failed
        ModelState.AddModelError("", "Invalid login attempt.");
        return View();
    }
}