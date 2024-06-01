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
    public class QuestionsController : Controller
    {
        private readonly IQuestionRepo _questionRepo;
        private readonly IAssessmentTestRepo _assessmentTestRepo;
        //private readonly ApplicationDbContext _context;

        public QuestionsController(IQuestionRepo questionRepo, IAssessmentTestRepo assessmentTestRepo)
        {
            _questionRepo = questionRepo;
            _assessmentTestRepo = assessmentTestRepo;

            //_context = context;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var questions = _questionRepo.GetAll();
            return View(questions);
            //var applicationDbContext = _context.Questions.Include(q => q.AssessmentTest);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = _questionRepo.GetById(id.Value);
            /*var question = await _context.Questions
                .Include(q => q.AssessmentTest)
                .FirstOrDefaultAsync(m => m.questionId == id);*/
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            ViewData["assesmentTestId"] = new SelectList(_assessmentTestRepo.GetAll(), "assessmentTestId", "assessmentTestId");
            //ViewData["assesmentTestId"] = new SelectList(_context.AssessmentTests, "assessmentTestId", "assessmentTestId");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("questionId,questionText,assesmentTestId")] Question question)
        {   
            ModelState.Remove("AssessmentTest");
            if (ModelState.IsValid)
            {
                _questionRepo.Add(question);
                //_context.Add(question);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["assesmentTestId"] = new SelectList(_assessmentTestRepo.GetAll(), "assessmentTestId", "assessmentTestId", question.assesmentTestId);
            //ViewData["assesmentTestId"] = new SelectList(_context.AssessmentTests, "assessmentTestId", "assessmentTestId", question.assesmentTestId);
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = _questionRepo.GetById(id.Value);
            //var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["assesmentTestId"] = new SelectList(_assessmentTestRepo.GetAll(), "assessmentTestId", "assessmentTestId", question.assesmentTestId);
            //ViewData["assesmentTestId"] = new SelectList(_context.AssessmentTests, "assessmentTestId", "assessmentTestId", question.assesmentTestId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("questionId,questionText,assesmentTestId")] Question question)
        {
            if (id != question.questionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _questionRepo.Update(question);
                    //_context.Update(question);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.questionId))
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
            ViewData["assesmentTestId"] = new SelectList(_assessmentTestRepo.GetAll(), "assessmentTestId", "assessmentTestId", question.assesmentTestId);
            //ViewData["assesmentTestId"] = new SelectList(_context.AssessmentTests, "assessmentTestId", "assessmentTestId", question.assesmentTestId);
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = _questionRepo.GetById(id.Value);
            /*var question = await _context.Questions
                .Include(q => q.AssessmentTest)
                .FirstOrDefaultAsync(m => m.questionId == id);*/
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = _questionRepo.GetById(id);
            //var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _questionRepo.Delete(question.questionId);
                //_context.Questions.Remove(question);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _questionRepo.Equals(id);
            //return _context.Questions.Any(e => e.questionId == id);
        }
    }
}
