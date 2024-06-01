using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Data;
using Microsoft.AspNetCore.Identity;
using ProfesionalProfile_District3_MVC.Repositories;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserRepository userRepository;

        public UsersController(ApplicationDbContext context)
        {
            userRepository = new UserRepository(context);
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Users.Include(u => u.Group);
            var applicationDbContext = userRepository.GetAll();
            return View(applicationDbContext);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var user = await _context.Users
                .Include(u => u.Group)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            var user = userRepository.GetById(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            //ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id");
            ViewData["GroupId"] = new SelectList(userRepository.GetAll(), "Id", "Id");
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
            //if (user.Email != null && _context.Users.Any(u => u.Email == user.Email))
            if(user.Email != null && userRepository.GetAll().Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Email already exists");
            }
            if (user.Email != null && !user.Email.Contains("@") && !user.Email.Contains("."))
            {
                ModelState.AddModelError("Email", "Email is not valid");
            }
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
                ///_context.Add(user);
                //await _context.SaveChangesAsync();
                userRepository.Add(user);
 
                return RedirectToAction("Index", "Home");
            }
            // ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id", user.GroupId);
            ViewData["GroupId"] = new SelectList(userRepository.GetAll(), "Id", "Id", user.GroupId);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var user = await _context.Users.FindAsync(id);
            var user = userRepository.GetById(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            // ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id", user.GroupId);
            ViewData["GroupId"] = new SelectList(userRepository.GetAll(), "Id", "Id", user.GroupId);
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
                    /*_context.Update(user);
                    await _context.SaveChangesAsync();*/
                    userRepository.Update(user);
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
            // ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id", user.GroupId);
            ViewData["GroupId"] = new SelectList(userRepository.GetAll(), "Id", "Id", user.GroupId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var user = await _context.Users
                .Include(u => u.Group)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            var user = userRepository.GetById(id.Value);
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
            //var user = await _context.Users.FindAsync(id);
            var user = userRepository.GetById(id);
            if (user != null)
            {
               // _context.Users.Remove(user);
               userRepository.Delete(id);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            //return _context.Users.Any(e => e.Id == id);
            return userRepository.GetAll().Any(e => e.Id == id);
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            /*
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);*/
            var user = userRepository.GetAll().FirstOrDefault(u => u.Email == email && u.Password == password);

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
