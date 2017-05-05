using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


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
