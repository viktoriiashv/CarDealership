using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Model
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
