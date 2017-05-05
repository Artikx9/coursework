using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace MinskTS.Models
{
    public class RouteStop
    {
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public int StopId { get; set; }
        public Stop Stop { get; set; }
    }

    public class ScheduleContext : DbContext
    {
        public DbSet<Stop> Stop { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<TimeTable> TimeTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RouteStop>()
            .HasKey(t => new { t.RouteId, t.StopId });

            modelBuilder.Entity<RouteStop>()
            .HasOne(sc => sc.Route)
            .WithMany(s => s.RouteStops)
            .HasForeignKey(sc => sc.RouteId);

            modelBuilder.Entity<RouteStop>()
            .HasOne(sc => sc.Stop)
            .WithMany(c => c.RouteStops)
            .HasForeignKey(sc => sc.StopId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=schedule.db");
        }   
    }
}
