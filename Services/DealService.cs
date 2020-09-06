using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.DAL;
using CarDealership.Models;

namespace CarDealership.Services
{
    public class DealService
    {
        CarDealershipContext db;

        public DealService(CarDealershipContext db)
        {
            this.db = db;
        }

        public List<Deal> GetDealList()
        {
            return db.Deals.ToList();
        }

        public Deal AddDeal(Deal deal)
        {
            db.Deals.Add(deal);
            db.SaveChanges();
            return deal;
        }

        public Deal GetDealByID(int id)
        {
            var q = db.Deals.Find(id);
            return q;
        }

        public Deal DeleteDeal(int id)
        {
            Deal deletedDeal = GetDealByID(id);
            db.Deals.Remove(deletedDeal);
            db.SaveChanges();
            return deletedDeal;
        }

        public Deal EditDeal(int id, Deal body)
        {
            Deal changedDeal = GetDealByID(id);
            Console.WriteLine(body.Date);
            if (body.CarID != 0)
            {
                changedDeal.CarID = body.CarID;
            }
            if (body.Date != null)
            {
                changedDeal.Date = body.Date;
            }
            if (body.ManagerID != 0)
            {
                changedDeal.ManagerID = body.ManagerID;
            }
            db.SaveChanges();
            return changedDeal;
        }
    }
}
