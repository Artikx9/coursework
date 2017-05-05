using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace MinskTS.Models
{
    public enum Types {Все = 0, Автобус , Тролейбус, Трамвай }
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
