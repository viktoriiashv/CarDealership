using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.DAL;
using CarDealership.Models;

namespace CarDealership.Services
{
    public class ManagerService
    {
        CarDealershipContext db;

        public ManagerService(CarDealershipContext db)
        {
            this.db = db;
        }

        public List<Manager> GetManagersList()
        {
            return db.Managers.ToList();
        }
    }
}
