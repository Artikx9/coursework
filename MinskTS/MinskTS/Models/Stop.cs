using System.Collections.Generic;


namespace MinskTS.Models
{
    public class Stop
     {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RouteStop> RouteStops { get; set; }

        public Stop()
        {
            RouteStops = new List<RouteStop>();
        }
     }
}
