using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class BlocksController : Controller
    {
        private readonly IBlocksRepository repository;

        public BlocksController(IBlocksRepository repository)
        {
            this.repository = repository;
        }

        // GET: Blocks
        public async Task<IActionResult> Index()
        {
            var blocks = await repository.GetBlocks();
            return View(blocks);
        }

        // GET: Blocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var block = await repository.GetBlock(id.Value);

            if (block == null)
            {
                return NotFound();
            }
            if (block == null)
            {
                return NotFound();
            }

            return View(block);
        }

        // GET: Blocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,sender,receiver,startingTimeStamp,reason")] Block block)
        {
            await repository.AddBlock(block);
            return View(block);
        }

        // GET: Blocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var block = await repository.GetBlock(id.Value);
            if (block == null)
            {
                return NotFound();
            }
            return View(block);
        }

        // POST: Blocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,sender,receiver,startingTimeStamp,reason")] Block block)
        {

            if (id != block.Id)
            {
                return BadRequest();
            }
            try
            {
                await repository.UpdateBlock(block);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlockExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return View(block);
        }

        // GET: Blocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var block = await repository.GetBlock(id.Value);
            if (block == null)
            {
                return NotFound();
            }

            await repository.DeleteBlock(block);
            return View(block);
        }

        // POST: Blocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var block = await repository.GetBlock(id);
            if (block == null)
            {
                return NotFound();
            }

            await repository.DeleteBlock(block);
            return View(block);
        }

        private bool BlockExists(int id)
        {
            return repository.BlockExists(id);
        }
    }
}
