using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GalaSoft.MvvmLight;

namespace MinskTS.Models
{



    public class Metr
    {
        
        public int Id { get; set; }
        public int Time { get; set; }
        public int WorkDays { get; set; }
        public int Friday { get; set; }
        public int Saturday { get; set; }
        public int Sunday { get; set; }
    }

    public class MetroContext : DbContext
    {

        public DbSet<Metr> Metro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=schedule.db");
        }
    }
}
