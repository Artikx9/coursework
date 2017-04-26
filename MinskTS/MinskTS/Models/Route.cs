using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace MinskTS.Models
{
   
        public class Rou
        {   [Key]
            public int Id { get; set; }
            public string RouteName { get; set; }
            public string Number { get; set; }
            public int Type { get; set; }
        }

        
    
}
