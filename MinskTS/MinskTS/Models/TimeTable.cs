namespace MinskTS.Models
{
    public class TimeTable
     {
        public int Id { get; set; }
        public string Hour { get; set; }
        public string Minutes { get; set; }
        public int RouteId { get; set; }
        public int StopId { get; set; }
     } 
}
