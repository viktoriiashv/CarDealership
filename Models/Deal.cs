using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Deal
    {
        public int ID { get; set; }
        public int ManagerID { get; set; }
        public int CarID { get; set; }
        public DateTime Date { get; set; }
        public Manager Manager { get; set; }
        public Car Car { get; set; }
    }
}
