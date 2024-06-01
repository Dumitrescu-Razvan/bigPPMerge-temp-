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
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class AnswersController(IAnswerRepo _answerRepo, IQuestionRepo _questionRepo) : Controller
    {
        private readonly IAnswerRepo _answerRepo = _answerRepo;
        private readonly IQuestionRepo _questionRepo = _questionRepo;

        // GET: Answers
        public async Task<IActionResult> Index()
        {
            return View(_answerRepo.GetAll());

            //var applicationDbContext = _context.Answers.Include(a => a.Question);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Answers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = _answerRepo.GetById(id.Value);

            /*var answer = await _context.Answers
                .Include(a => a.Question)
                .FirstOrDefaultAsync(m => m.answerId == id);
            if (answer == null)
            {
                return NotFound();
            }*/

            return View(answer);
        }

        // GET: Answers/Create
        public IActionResult Create()
        {
            /*Answer answer = new Answer();
            answer.Question = new Question();
            _answerRepo.Add(answer);*/
            ViewData["questionId"] = new SelectList(_questionRepo.GetAll(), "questionId", "questionId");
            //ViewData["questionId"] = new SelectList(_context.Questions, "questionId", "questionId");
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("answerId,answerText,questionId,isCorrect")] Answer answer)
        {   
            ModelState.Remove("Question");
            
            if (ModelState.IsValid)
            {
                _answerRepo.Add(answer);
                return RedirectToAction(nameof(Index));
                /*_context.Add(answer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));*/
            }
            ViewData["questionId"] = new SelectList(_answerRepo.GetAll(), "questionId", "questionId", answer.questionId);
            //ViewData["questionId"] = new SelectList(_context.Questions, "questionId", "questionId", answer.questionId);
            return View(answer);
        }

        // GET: Answers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = _answerRepo.GetById(id.Value);
            //var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }
            ViewData["questionId"] = new SelectList(_answerRepo.GetAll(), "questionId", "questionId", answer.questionId);
            //ViewData["questionId"] = new SelectList(_context.Questions, "questionId", "questionId", answer.questionId);
            return View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("answerId,answerText,questionId,isCorrect")] Answer answer)
        {
            if (id != answer.answerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _answerRepo.Update(answer);
                    /*_context.Update(answer);
                    await _context.SaveChangesAsync();*/
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswerExists(answer.answerId))
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
            ViewData["questionId"] = new SelectList(_answerRepo.GetAll(), "questionId", "questionId", answer.questionId);
            //ViewData["questionId"] = new SelectList(_context.Questions, "questionId", "questionId", answer.questionId);
            return View(answer);
        }

        // GET: Answers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var answer = _answerRepo.GetById(id.Value);
            /*var answer = await _context.Answers
                .Include(a => a.Question)
                .FirstOrDefaultAsync(m => m.answerId == id);*/
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var answer = await _context.Answers.FindAsync(id);
            if (answer != null)
            {
                _context.Answers.Remove(answer);
            }*/

            //await _context.SaveChangesAsync();
            _answerRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AnswerExists(int id)
        {
            try
            {
                _answerRepo.GetById(id);
                return true;
            } catch (Exception)
            {
                return false;
            }
            //return _context.Answers.Any(e => e.answerId == id);
        }
    }
}
