using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MinskTS.Models
{
    public enum Types {All = 0, Bus , Trolleybus, Tramway }
    public class Route
        {   [Key]
            public int Id { get; set; }
            public string RouteName { get; set; }
            public string Number { get; set; }
            public Types Type { get; set; }
            public List<RouteStop> RouteStops { get; set; }

           public Route()
           {
            RouteStops = new List<RouteStop>();
           }
        }

        
    
}
