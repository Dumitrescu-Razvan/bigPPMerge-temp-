using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class CertificatesController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly ICertificateRepo _certificateRepo;
        private readonly IUserRepo _userRepo;

        public CertificatesController(ICertificateRepo certificateRepo, IUserRepo userRepo)
        {
            _certificateRepo = certificateRepo;
            _userRepo = userRepo;
        }

        // GET: Certificates
        public async Task<IActionResult> Index()
        {
            var certificates = _certificateRepo.GetAll();
            return View(certificates);
            //var applicationDbContext = _context.Certificates.Include(c => c.User);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Certificates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate = _certificateRepo.GetById(id.Value);
            /*var certificate = await _context.Certificates
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.certificateId == id);*/
            if (certificate == null)
            {
                return NotFound();
            }

            return View(certificate);
        }

        // GET: Certificates/Create
        public IActionResult Create()
        {
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId");
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId");
            return View();
        }

        // POST: Certificates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("certificateId,name,issuedBy,description,issuedDate,expirationDate,userId")] Certificate certificate)
        {   
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                _certificateRepo.Add(certificate);
                /*_context.Add(certificate);
                await _context.SaveChangesAsync();*/
                return RedirectToAction(nameof(Index));
            }
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", certificate.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", certificate.userId);
            return View(certificate);
        }

        // GET: Certificates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate = _certificateRepo.GetById(id.Value);
            //var certificate = await _context.Certificates.FindAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", certificate.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", certificate.userId);
            return View(certificate);
        }

        // POST: Certificates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("certificateId,name,issuedBy,description,issuedDate,expirationDate,userId")] Certificate certificate)
        {
            if (id != certificate.certificateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _certificateRepo.Update(certificate);
                    //_context.Update(certificate);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificateExists(certificate.certificateId))
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
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", certificate.userId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", certificate.userId);
            return View(certificate);
        }

        // GET: Certificates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate = _certificateRepo.GetById(id.Value);
            //var certificate = await _context.Certificates
            //    .Include(c => c.User)
            //    .FirstOrDefaultAsync(m => m.certificateId == id);
            if (certificate == null)
            {
                return NotFound();
            }

            return View(certificate);
        }

        // POST: Certificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var certificate = await _context.Certificates.FindAsync(id);
            var certificate = _certificateRepo.GetById(id);
            if (certificate != null)
            {
                _certificateRepo.Delete(id);
                //_context.Certificates.Remove(certificate);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificateExists(int id)
        {
            return _certificateRepo.GetById(id) != null;
            //return _context.Certificates.Any(e => e.certificateId == id);
        }
    }
}
