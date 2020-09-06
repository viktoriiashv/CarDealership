using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.DAL;
using CarDealership.Models;

namespace CarDealership.Services
{
    public class CarService
    {

        CarDealershipContext db;

        public CarService(CarDealershipContext db)
        {
            this.db = db;
        }

        public List<Car> GetCarsList()
        {
            return db.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            var q = db.Cars.Find(id);
            return q;
        }

        public Car AddCar(Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
            return car;
        }
    }
}
