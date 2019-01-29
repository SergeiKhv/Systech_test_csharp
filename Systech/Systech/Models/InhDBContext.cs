using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systech.Models
{
    public class InhDBContext : DbContext
    {        

        public InhDBContext()
        {
            if (!File.Exists(@"C:\Users\HighTension\Desktop\systech\Database\Sample.db"))
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=C:\Users\HighTension\Desktop\systech\Database\Sample.db");
        }

        public DbSet<Person> People { get; set; }
    }
}
