using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;


namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class BlocksRepository : IBlocksRepository
    {
        private readonly ApplicationDbContext context;

        public BlocksRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Block>> GetBlocks()
        {
            return await context.Block.ToListAsync();
        }

        public async Task<Block> GetBlock(int id)
        {
            return await context.Block.FindAsync(id);
        }

        public async Task UpdateBlock(Block block)
        {
            context.Entry(block).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlockExists(block.Id))
                {
                    throw new KeyNotFoundException("Block not found");
                }
                else
                {
                    throw;
                }
            }
        }

        public bool BlockExists(int id)
        {
            return context.Block.Any(e => e.Id == id);
        }

        public async Task AddBlock(Block block)
        {
            context.Block.Add(block);
            await context.SaveChangesAsync();
           
        }

        public async Task DeleteBlock(Block block)
        {
            context.Block.Remove(block);
            await context.SaveChangesAsync();
        }

    }
}

