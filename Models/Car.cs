using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Mark { get; set; }
        public string Class { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public double Cost { get; set; }
    }
}
