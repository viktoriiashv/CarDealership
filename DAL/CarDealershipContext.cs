using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using CarDealership.Models;

namespace CarDealership.DAL
{
    public class CarDealershipContext : DbContext

    {
        public CarDealershipContext(DbContextOptions<CarDealershipContext> options) : base(options)
        {

        }
        public DbSet<Manager> Managers { get; set; }
        
    }
}