using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using Microsoft.AspNetCore.Identity;
using ProfesionalProfile_District3_MVC.Repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepo _userRepo;
        //private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UsersController(IUserRepo userRepo, UserManager<User> userManager)
        {
            _userRepo = userRepo;
            _userManager = userManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(_userRepo.GetAll());
            //var applicationDbContext = _context.Users.Include(u => u.Group);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userRepo.GetById(id.Value);
            /*var user = await _context.Users
                .Include(u => u.Group)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_userRepo.GetAll(), "Id", "Id");
            //ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password,Email,ConfirmationPassword,RegistrationDate,FollowingCount,FollowersCount,UserSession,GroupId,Summary,DarkTheme,Phone,WebsiteURL")] User user)
        {
            user.Id = Guid.NewGuid().ToString();
            var result =  await _userManager.CreateAsync(user, user.Password);
            
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewData["GroupId"] = new SelectList(_userRepo.GetAll(), "Id", "Id", user.GroupId);
            return View(user);

        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userRepo.GetById(id.Value);
            /*var user = await _context.Users.FindAsync(id);*/
            if (user == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_userRepo.GetAll(), "Id", "Id", user.GroupId);
            //ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id", user.GroupId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Email,ConfirmationPassword,RegistrationDate,FollowingCount,FollowersCount,UserSession,GroupId,Summary,DarkTheme,Phone,WebsiteURL")] User user)
        {
            if (id.ToString() != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _userRepo.Update(user);
                    //_context.Update(user);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(int.Parse(user.Id)))
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
            ViewData["GroupId"] = new SelectList(_userRepo.GetAll(), "Id", "Id", user.GroupId);
            //ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id", user.GroupId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userRepo.GetById(id.Value);
            /*var user = await _context.Users
                .Include(u => u.Group)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = _userRepo.GetById(id);
            /*var user = await _context.Users.FindAsync(id);*/
            if (user != null)
            {
                _userRepo.Delete(id);
                /*_context.Users.Remove(user);*/
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _userRepo.GetAll().Any(e => e.Id == id.ToString());
            //return _context.Users.Any(e => e.Id == id);
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            List<User> users = _userRepo.GetAll().ToList();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Email == email && users[i].Password == password)
                {
                    return RedirectToAction("ProfilePage", "Home");
                }
            }
            //print all the users
            /*var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            */

            // Login failed
            ModelState.AddModelError("", "Invalid login attempt.");
            //return an error message
            return RedirectToAction("Index", "Home");
        }
    }
}
