using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.DAL;
using CarDealership.Models;

namespace CarDealership.Services
{
    public class ModelService
    {
        CarDealershipContext db;
        public ModelService(CarDealershipContext db)
        {
            this.db = db;
        }

        internal List<Model> GetModelsList()
        {
            Console.WriteLine(db.Models);
            Console.WriteLine(db.Managers);
            return db.Models.ToList();

        }

        internal Model EditModel(int id, Model body)
        {
            Model changedModel = GetModelById(id);
            if (body.Title != null)
            {
                changedModel.Title = body.Title;
            }
            db.SaveChanges();
            return changedModel;
        }

        internal Model DeleteModel(int id)
        {
            Model deletedModel = GetModelById(id);
            db.Models.Remove(deletedModel);
            db.SaveChanges();
            return deletedModel;
        }

        internal Model AddModel(Model model)
        {
            db.Models.Add(model);
            db.SaveChanges();
            return model;
        }

        internal Model GetModelById(int id)
        {
            var q = db.Models.Find(id);
            return q;
        }
    }
}
