using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment7.Models;

namespace Assignment7.Data
{
    public class TempContext : DbContext
    {
        public TempContext (DbContextOptions<TempContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment7.Models.Posts> Posts { get; set; } = default!;
    }
}
