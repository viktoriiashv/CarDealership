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

        public Manager GetMaxCountDealManager(DateTime startDate, DateTime endDate)
        {
            var query = db.Managers
               .OrderByDescending(m => m.Deals.Where(d => startDate <= d.Date && d.Date <= endDate).Count())
               .Where(m => m.Deals.Where(d => startDate <= d.Date && d.Date <= endDate).Count() > 0);

            return query.FirstOrDefault();
        }
    }
}
