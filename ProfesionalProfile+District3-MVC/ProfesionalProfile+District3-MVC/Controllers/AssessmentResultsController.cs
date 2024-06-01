using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Repositories;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class AssessmentResultsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IAssessmentResultRepo _assessmentResultRepo;
        private readonly IAssessmentTestRepo _assessmentTestRepo;
        private readonly IUserRepo _userRepo;

        public AssessmentResultsController(IAssessmentResultRepo assessmentResultRepo, IAssessmentTestRepo assessmentTestRepo, IUserRepo userRepo)
        {
            _assessmentResultRepo = assessmentResultRepo;
            _assessmentTestRepo = assessmentTestRepo;
            _userRepo = userRepo;
        }

        // GET: AssessmentResults
        public async Task<IActionResult> Index()
        {
            return View(_assessmentResultRepo.GetAll());
            //var applicationDbContext = _context.AssessmentResults.Include(a => a.AssessmentTest).Include(a => a.User);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: AssessmentResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessmentResult = _assessmentResultRepo.GetById(id.Value);
            /*var assessmentResult = await _context.AssessmentResults
                .Include(a => a.AssessmentTest)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.assesmentResultId == id);*/
            if (assessmentResult == null)
            {
                return NotFound();
            }

            return View(assessmentResult);
        }

        // GET: AssessmentResults/Create
        public IActionResult Create()
        {
            ViewData["asssmentTestId"] = new SelectList(_assessmentTestRepo.GetAll(), "assesmentTestId", "assesmentTestId");
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId");
            //ViewData["assesmentTestId"] = new SelectList(_context.AssessmentTests, "assessmentTestId", "assessmentTestId");
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId");
            return View();
        }

        // POST: AssessmentResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("assesmentResultId,assesmentTestId,score,userId,testDate")] AssessmentResult assessmentResult)
        {   
            ModelState.Remove("AssessmentTest");
            ModelState.Remove("User");
            
            if (ModelState.IsValid)
            {
                _assessmentResultRepo.Add(assessmentResult);
                //_context.Add(assessmentResult);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["assesmentTestId"] = new SelectList(_context.AssessmentTests, "assessmentTestId", "assessmentTestId", assessmentResult.assesmentTestId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", assessmentResult.userId);
            ViewData["asssmentTestId"] = new SelectList(_assessmentTestRepo.GetAll(), "assesmentTestId", "assesmentTestId", assessmentResult.assesmentTestId);
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", assessmentResult.userId);
            return View(assessmentResult);
        }

        // GET: AssessmentResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessmentResult = _assessmentResultRepo.GetById(id.Value);
            //var assessmentResult = await _context.AssessmentResults.FindAsync(id);
            if (assessmentResult == null)
            {
                return NotFound();
            }
            //ViewData["assesmentTestId"] = new SelectList(_context.AssessmentTests, "assessmentTestId", "assessmentTestId", assessmentResult.assesmentTestId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", assessmentResult.userId);
            ViewData["asssmentTestId"] = new SelectList(_assessmentTestRepo.GetAll(), "assesmentTestId", "assesmentTestId", assessmentResult.assesmentTestId);
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", assessmentResult.userId);
            return View(assessmentResult);
        }

        // POST: AssessmentResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("assesmentResultId,assesmentTestId,score,userId,testDate")] AssessmentResult assessmentResult)
        {
            if (id != assessmentResult.assesmentResultId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _assessmentResultRepo.Update(assessmentResult);
                    //_context.Update(assessmentResult);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssessmentResultExists(assessmentResult.assesmentResultId))
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
            ViewData["asssmentTestId"] = new SelectList(_assessmentTestRepo.GetAll(), "assesmentTestId", "assesmentTestId", assessmentResult.assesmentTestId);
            ViewData["userId"] = new SelectList(_userRepo.GetAll(), "userId", "userId", assessmentResult.userId);
            //ViewData["assesmentTestId"] = new SelectList(_context.AssessmentTests, "assessmentTestId", "assessmentTestId", assessmentResult.assesmentTestId);
            //ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", assessmentResult.userId);
            return View(assessmentResult);
        }

        // GET: AssessmentResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessmentResult = _assessmentResultRepo.GetById(id.Value);
            //var assessmentResult = await _context.AssessmentResults
            //    .Include(a => a.AssessmentTest)
            //    .Include(a => a.User)
            //    .FirstOrDefaultAsync(m => m.assesmentResultId == id);
            if (assessmentResult == null)
            {
                return NotFound();
            }

            return View(assessmentResult);
        }

        // POST: AssessmentResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assessmentResult = _assessmentResultRepo.GetById(id);
            //var assessmentResult = await _context.AssessmentResults.FindAsync(id);
            if (assessmentResult != null)
            {
                _assessmentResultRepo.Delete(id);
                //_context.AssessmentResults.Remove(assessmentResult);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssessmentResultExists(int id)
        {
            return _assessmentResultRepo.GetAll().Any(e => e.assesmentResultId == id);
            //return _context.AssessmentResults.Any(e => e.assesmentResultId == id);
        }
    }
}
