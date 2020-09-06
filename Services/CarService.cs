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

        public Car DeleteCar(int id)
        {
            Car deletedCar = GetCarById(id);
            db.Cars.Remove(deletedCar);
            db.SaveChanges();
            return deletedCar;
        }

        public Car EditCar(int id, Car body)
        {
            Car changedCar = GetCarById(id);
            if (body.Year!= 0)
            {
                changedCar.Year = body.Year;
            }
            if (body.Cost != 0)
            {
                changedCar.Cost = body.Cost;
            }
            if (body.ClassID != 0)
            {
                changedCar.ClassID = body.ClassID;
            }
            if (body.MarkID != 0)
            {
                changedCar.MarkID = body.MarkID;
            }
            if (body.ModelID != 0)
            {
                changedCar.ModelID = body.ModelID;
            }
            db.SaveChanges();
            return changedCar;
        }
    }
}
