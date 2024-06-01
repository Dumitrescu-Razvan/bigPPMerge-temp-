using System;
using System.Collections.Generic;
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
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Comment>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetComment(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task UpdateComment(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(comment.Id))
                {
                    throw new KeyNotFoundException("Comment not found");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                throw new KeyNotFoundException("Comment not found");
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
