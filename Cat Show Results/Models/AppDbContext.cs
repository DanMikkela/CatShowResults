using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cat_Show_Results.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Breed> Breeds { get; set; }

    }

}

