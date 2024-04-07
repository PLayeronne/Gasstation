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
    public class FuelInventoryRepository
    {
        public IEnumerable<FuelInventory> GetAll()
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.FuelInventories.Include(x => x.FuelType).ToList();
            }
        }

        public FuelInventory Get(int id)
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.FuelInventories.Include(x => x.FuelType).FirstOrDefault(x => x.Id == id);
            }
        }

        public int Add(FuelInventory FuelInventory)
        {
            using (var ctx = new DBEFContext())
            {
                var obj = ctx.FuelInventories.Add(FuelInventory);
                ctx.SaveChanges();
                return obj.Entity.Id;
            }
        }

        public void Update(FuelInventory updeteFuelInventory)
        {
            using (var ctx = new DBEFContext())
            {
                var fuelingStation = ctx.FuelInventories.Find(updeteFuelInventory.Id);
                if (fuelingStation.QuantityAvailable != updeteFuelInventory.QuantityAvailable)
                {
                    fuelingStation.QuantityAvailable = updeteFuelInventory.QuantityAvailable;
                }
                if (fuelingStation.LastUpdateDateTime != updeteFuelInventory.LastUpdateDateTime)
                {
                    fuelingStation.LastUpdateDateTime = updeteFuelInventory.LastUpdateDateTime;
                }

                if (fuelingStation.MinStockLevel != updeteFuelInventory.MinStockLevel)
                {
                    fuelingStation.MinStockLevel = updeteFuelInventory.MinStockLevel;
                }

                if (fuelingStation.OtherDetails != updeteFuelInventory.OtherDetails)
                {
                    fuelingStation.OtherDetails = updeteFuelInventory.OtherDetails;
                }
                if (fuelingStation.FuelType != updeteFuelInventory.FuelType)
                {
                    fuelingStation.FuelType = updeteFuelInventory.FuelType;
                }

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new DBEFContext())
            {
                ctx.FuelInventories.Remove(ctx.FuelInventories.Find(id));
                ctx.SaveChanges();
            }
        }
    }
}
