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

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepo _userRepo;
        //private readonly ApplicationDbContext _context;

        public UsersController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
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
        public async Task<IActionResult> Create([Bind("Id,Username,Password,Email,ConfirmationPassword,RegistrationDate,FollowingCount,FollowersCount,UserSession,GroupId,Summary,DarkTheme,Phone,WebsiteURL")] User user)
        {
            if (user.Password != user.ConfirmationPassword)
            {
                ModelState.AddModelError("ConfirmationPassword", "Password and Confirmation Password do not match");
            }
            if (user.Username != null && _userRepo.GetAll().Any(u => u.Username == user.Username))
            {
                ModelState.AddModelError("Username", "Username already exists");
            }
            if (user.Email != null && _userRepo.GetAll().Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Email already exists");
            }
            if (user.Email != null && user.Email != null && !user.Email.Contains("@") && !user.Email.Contains("."))
            {
                ModelState.AddModelError("Email", "Email is not valid");
            }
            /*if (user.Email != null && !user.Email.Contains("@") && !user.Email.Contains("."))
            {
                ModelState.AddModelError("Email", "Email is not valid");
            }*/
            user.RegistrationDate = DateTime.Now;
            user.FollowersCount = 0;
            user.FollowingCount = 0;
            user.UserSession = TimeSpan.FromHours(1);
            if (user.Phone.Length != 10 || user.Phone.Count(c => char.IsDigit(c)) != 10)
            {
                ModelState.AddModelError("Phone", "Phone number must be 10 digits and start with 07");
            }
            if (user.WebsiteURL != null && !user.WebsiteURL.Contains("http://") && !user.WebsiteURL.Contains("."))
            {
                ModelState.AddModelError("WebsiteURL", "Website URL must start with http://");
            }
            if (ModelState.IsValid)
            {
                _userRepo.Add(user);
                /*_context.Add(user);
                await _context.SaveChangesAsync();
 */
                return RedirectToAction("Index", "Home");
            }
            ViewData["GroupId"] = new SelectList(_userRepo.GetAll(), "Id", "Id", user.GroupId);
            //ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id", user.GroupId);
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
            if (id != user.Id)
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
                    if (!UserExists(user.Id))
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
            return _userRepo.GetAll().Any(e => e.Id == id);
            //return _context.Users.Any(e => e.Id == id);
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = _userRepo.GetAll().FirstOrDefault(u => u.Email == email && u.Password == password);
            /*var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            */
            if (user != null)
                // Login successful
                // Here you can add code to log the user in, like setting a cookie or a session variable
                return RedirectToAction("ProfilePage", "Home");

            // Login failed
            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }
    }
}
