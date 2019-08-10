using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFitness.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<Session> Timetable { get; set; }

    }
}
