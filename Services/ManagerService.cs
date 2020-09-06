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

        public Manager EditManager(int id, Manager body)
        {
            Manager changedManager = GetManagerByID(id);
            if (body.FirstName != null)
            {
                changedManager.FirstName = body.FirstName;
            }
            if (body.LastName != null)
            {
                changedManager.LastName = body.LastName;
            }
            if (body.PhoneNumber != null)
            {
                changedManager.PhoneNumber = body.PhoneNumber;
            }
            if (body.AdditionalInfo != null)
            {
                changedManager.AdditionalInfo = body.AdditionalInfo;
            }
            db.SaveChanges();
            return changedManager;
        }

        public Manager DeleteManager(int id)
        {
            Manager deletedManager = GetManagerByID(id);
            db.Managers.Remove(deletedManager);
            db.SaveChanges();
            return deletedManager;
        }

        public Manager GetManagerByID(int id)
        {
            var q = db.Managers.Find(id);
            return q;
        }

        public Manager AddManager(Manager manager)
        {
            db.Managers.Add(manager);
            db.SaveChanges();
            return manager;
        }

        public List<Tuple<Manager, Mark>> GetManagerBestsellerMarkByCount()
        {
            var managersQuery = db.Managers.ToList();
            List<Tuple<Manager, Mark>> managersBestMark = new List<Tuple<Manager, Mark>>();
            foreach (Manager manager in managersQuery)
            {
                var q = db.Cars
                    .Where(c => c.Deals.Where(d => d.Manager == manager).Count() > 0)// count > 0 - manager sold this car min 1 time
                    .Select(c => new { c.MarkID, dealsCount = c.Deals.Where(d => d.Manager == manager).Count() })// select markid and amount deals with this car sold by current manager
                    .ToList()
                    .GroupBy(c => c.MarkID)
                    .Select(x => new { x.Key, Count = x.Sum(c => c.dealsCount) })//select MarkID and count of deals of this mark 
                    .ToList()
                    .OrderByDescending(x => x.Count);//get bestseller mark by count, it`s on top

                var mq = db.Mark.Where(m => m.ID == q.FirstOrDefault().Key);//select mark entity by id

                managersBestMark.Add(Tuple.Create(manager, mq.FirstOrDefault()));
            }

            return managersBestMark;
        }

        public List<Tuple<Manager, Mark>> GetManagerBestsellerMarkBySum()
        {
            var managersQuery = db.Managers.ToList();
            List<Tuple<Manager, Mark>> managersBestMark = new List<Tuple<Manager, Mark>>();
            foreach (Manager manager in managersQuery)
            {
                var q = db.Cars
                    .Where(c => c.Deals.Where(d => d.Manager == manager).Count() > 0)// count > 0 - manager sold this car min 1 time
                    .Select(c => new { c.MarkID, dealsCount = c.Deals.Where(d => d.Manager == manager).Count(), c.Cost })// select markid, amount deals with this car sold by current manager, and cost of this car 
                    .ToList()
                    .GroupBy(c => c.MarkID)//result is key markid and value sum of profit from solded car by mark 
                    .Select(x => new { x.Key, Sum = x.Sum(c => c.dealsCount * c.Cost) })//multiply cost of car and amount of cars
                    .ToList()
                    .OrderByDescending(x => x.Sum);//get bestseller mark by sum, it`s on top

                var mq = db.Mark.Where(m => m.ID == q.FirstOrDefault().Key);//select mark entity by id

                managersBestMark.Add(Tuple.Create(manager, mq.FirstOrDefault()));
            }

            return managersBestMark;
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
