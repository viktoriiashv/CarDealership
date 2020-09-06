using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.Models;
using CarDealership.Services;
using CarDealership.DAL;

namespace CarDealership.Services
{
    public class ClassService
    {
        CarDealershipContext db;
        public ClassService(CarDealershipContext db)
        {
            this.db = db;
        }

        internal List<Class> GetClassesList()
        {
            return db.Classes.ToList();
        }

        internal Class EditClass(int id, Class body)
        {
            Class changedClass = GetClassById(id);
            if (body.Title != null)
            {
                changedClass.Title = body.Title;
            }
            db.SaveChanges();
            return changedClass;
        }

        internal Class DeleteClass(int id)
        {
            Class deletedClass = GetClassById(id);
            db.Classes.Remove(deletedClass);
            db.SaveChanges();
            return deletedClass;
        }

        internal Class AddClass(Class myclass)
        {
            db.Classes.Add(myclass);
            db.SaveChanges();
            return myclass;
        }

        internal Class GetClassById(int id)
        {
            var q = db.Classes.Find(id);
            return q;
        }
    }
}
