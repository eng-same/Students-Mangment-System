using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developmentSpace1
{
    class AppDbContext:DbContext
    {
        public DbSet<Student> Students { set;get ; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-CR3USUC;Database=StudentsSys;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
