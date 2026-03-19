using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeenTitansRP
{
    public class TeenTitansContextFactory : IDesignTimeDbContextFactory<TeenTitansContext>
    {
        public TeenTitansContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TeenTitansContext>();

            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=TeenTitansDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new TeenTitansContext(optionsBuilder.Options);
        }
    }
}
