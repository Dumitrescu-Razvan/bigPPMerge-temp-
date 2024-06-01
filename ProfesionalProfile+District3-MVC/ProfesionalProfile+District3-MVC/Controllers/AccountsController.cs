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
    public class AccountsController : Controller
    {
        private AccountRepository accountRepository;
        private UserRepository userRepository;

        public AccountsController(ApplicationDbContext context)
        {
            accountRepository = new AccountRepository(context);
            userRepository = new UserRepository(context);
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            /*var applicationDbContext = _context.Account.Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());*/
            return View(accountRepository.GetAll());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var account = await _context.Account
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            var account = accountRepository.GetById(id.Value);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            //ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            ViewData["UserId"] = new SelectList(accountRepository.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CardNumber,HolderName,ExpirationDate,Cvv,UserId")] Account account)
        {
            if (ModelState.IsValid)
            {
                /*
                _context.Add(account);
                await _context.SaveChangesAsync();*/

                accountRepository.Add(account);

                //accountRepository.Create(account);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", account.UserId);
            ViewData["UserId"] = new SelectList(userRepository.GetAll(), "Id", "Id", account.UserId);
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var account = await _context.Account.FindAsync(id);
            var account = accountRepository.GetById(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            //ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", account.UserId);
            ViewData["UserId"] = new SelectList(userRepository.GetAll(), "Id", "Id", account.UserId);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CardNumber,HolderName,ExpirationDate,Cvv,UserId")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*
                    _context.Update(account);
                    await _context.SaveChangesAsync();*/
                    accountRepository.Update(account);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
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
            //ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", account.UserId);
            ViewData["UserId"] = new SelectList(userRepository.GetAll(), "Id", "Id", account.UserId);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           /* var account = await _context.Account
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);*/
           var account = accountRepository.GetById(id.Value);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var account = await _context.Account.FindAsync(id);
            var account = accountRepository.GetById(id);
            if (account != null)
            {
                //_context.Account.Remove(account);
                accountRepository.Delete(account.Id);
            }

           // await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            //return _context.Account.Any(e => e.Id == id);
            var account = accountRepository.GetById(id);
            if (account != null)
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
