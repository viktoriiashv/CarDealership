using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Car
    {
        public int ID { get; set; }
        public int MarkID { get; set; }
        public int ClassID { get; set; }
        public int ModelID { get; set; }
        public int Year { get; set; }
        public double Cost { get; set; }
        public ICollection<Deal> Deals { get; set; }

        public Mark Mark { get; set; }
        public Class Class { get; set; }
        public Model Model { get; set; }
    }
}
