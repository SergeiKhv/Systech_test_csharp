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
			//добавить расположение ваше базы
            if (!File.Exists())
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
			//добавить расположение ваше базы
            optionbuilder.UseSqlite();
        }

        public DbSet<Person> People { get; set; }
    }
}
