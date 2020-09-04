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
    }
}
