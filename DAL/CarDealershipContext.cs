using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;


namespace CarDealership.DAL
{
    public class CarDealershipContext : DbContext
    {
        public CarDealershipContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Mark> Mark { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}

