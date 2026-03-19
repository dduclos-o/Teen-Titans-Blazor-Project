using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TeenTitansRP
{
    // Characters, Powers, Teams are my model classes that I will use for the construction of my database
    public class TeenTitansContext : DbContext
    {
        public TeenTitansContext(DbContextOptions<TeenTitansContext> options)
        : base(options)
        {
        }

        // These methods will generate three tables in my database (Characters, Powers, Teams)
        public DbSet<Character> Characters { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=TeenTitansDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
