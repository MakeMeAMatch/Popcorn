using Microsoft.EntityFrameworkCore;
using Popcorn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Popcorn.Data
{
    public class PopcornDbContext : DbContext
    {
        public PopcornDbContext(DbContextOptions<PopcornDbContext> options) : base(options)
        {

        }

        public DbSet<Responses> Responses { get; set; }
        public DbSet<Matches> Matches { get; set; }
        public DbSet<Profiles> Users { get; set; }

    }
}
