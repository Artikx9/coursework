using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace MinskTS.Models
{
     public class TT
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int RouteId { get; set; }
        public int StopId { get; set; }
    }

    public class TimeTableContext : DbContext
    {
       public DbSet<TT> TimeTable { get; set; }
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=schedule.db");
        }
    }
}
