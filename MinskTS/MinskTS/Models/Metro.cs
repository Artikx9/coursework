using Microsoft.EntityFrameworkCore;

namespace MinskTS.Models
{
    public class Metro
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
        public DbSet<Metro> Metro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=schedule.db");
        }
    }
}
