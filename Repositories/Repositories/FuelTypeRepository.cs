using Core.DBContext;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class FuelTypeRepository
    {
        public IEnumerable<FuelType> GetAll()
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.FuelTypes.Include(x => x.FuelingStation).ToList();
            }
        }

        public FuelType Get(int id)
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.FuelTypes.Include(x => x.FuelingStation).FirstOrDefault(x => x.Id == id);
            }
        }

        public int Add(FuelType FuelType)
        {
            using (var ctx = new DBEFContext())
            {
                var obj = ctx.FuelTypes.Add(FuelType);
                ctx.SaveChanges();
                return obj.Entity.Id;
            }
        }

        public void Update(FuelType updeteFuelType)
        {
            using (var ctx = new DBEFContext())
            {
                var fuelType = ctx.FuelTypes.Find(updeteFuelType.Id);
                if (fuelType.Name != updeteFuelType.Name)
                {
                    fuelType.Name = updeteFuelType.Name;
                }
                if (fuelType.UnitOfMeasurement != updeteFuelType.UnitOfMeasurement)
                {
                    fuelType.UnitOfMeasurement = updeteFuelType.UnitOfMeasurement;
                }

                if (fuelType.PricePerUnit != updeteFuelType.PricePerUnit)
                {
                    fuelType.PricePerUnit = updeteFuelType.PricePerUnit;
                }



                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new DBEFContext())
            {
                ctx.FuelTypes.Remove(ctx.FuelTypes.Find(id));
                ctx.SaveChanges();
            }
        }
    }
}
