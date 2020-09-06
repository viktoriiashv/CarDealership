using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.DAL;
using CarDealership.Models;

namespace CarDealership.Services
{
    public class MarkService
    {
        CarDealershipContext db;
        public MarkService(CarDealershipContext db)
        {
            this.db = db;
        }

        internal List<Mark> GetMarkList()
        {
            return db.Marks.ToList();
        }

        internal Mark EditMark(int id, Mark body)
        {
            Mark changedMark = GetMarkById(id);
            if (body.Title != null)
            {
                changedMark.Title = body.Title;
            }
            db.SaveChanges();
            return changedMark;
        }

        internal Mark DeleteMark(int id)
        {
            Mark deletedMark = GetMarkById(id);
            db.Marks.Remove(deletedMark);
            db.SaveChanges();
            return deletedMark;
        }

        internal Mark AddMark(Mark mark)
        {
            db.Marks.Add(mark);
            db.SaveChanges();
            return mark;
        }

        internal Mark GetMarkById(int id)
        {
            var q = db.Marks.Find(id);
            return q;
        }
    }
}
