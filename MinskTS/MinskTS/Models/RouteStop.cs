using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace MinskTS.Models
{


    public class RS
    {
        [Key]
        public int RouteId { get; set; }
        public string StopId { get; set; }
      
    }

    public class ScheduleContext : DbContext
    {
        public DbSet<Stops> Stop { get; set; }
        public DbSet<Rou> Route { get; set; }
        public DbSet<RS> RouteStop { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=schedule.db");
        }
    }
}
