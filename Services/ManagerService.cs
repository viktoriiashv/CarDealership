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

        internal List<Tuple<Manager, Mark>> GetManagerBestsellerMarkBySum()
        {
            var managersQuery = db.Managers.ToList();
            List<Tuple<Manager, Mark>> managersBestMark = new List<Tuple<Manager, Mark>>();

            foreach (Manager m in managersQuery)
            {
                var q = db.Cars
                    .Where(c => c.Deals.Where(d => d.Manager == m).Count() > 0)// count > 0 - manager sold this car min 1 time
                    .Select(c => new { c.MarkID, Deals = c.Deals.Where(d => d.Manager == m).Count(), c.Cost })// select markid, amount deals with this car sold by current manager, and cost of this car 
                    .ToList()
                    .GroupBy(c => c.MarkID)//result is key markid and value sum of profit from solded car by mark 
                    .Select(x => new { x.Key, Sum = x.Sum(c => c.Deals * c.Cost) })//multiply cost of car and amount of cars
                    .ToList()
                    .OrderByDescending(x => x.Sum);//get bestseller mark by sum, it`s on top

                var mq = db.Mark.Where(m => m.ID == q.FirstOrDefault().Key);//select mark entity by id

                managersBestMark.Add(Tuple.Create(m, mq.FirstOrDefault()));
            }

            return managersBestMark;
        }
    }
}
