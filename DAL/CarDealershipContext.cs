﻿using System;
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

        public DbSet<Manager> Values { get; set; }
    }
}

