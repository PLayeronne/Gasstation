using Core.DBContext;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class FuelingStationRepository
    {
        public IEnumerable<FuelingStation> GetAll()
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.FuelingStations.ToList();
            }
        }

        public FuelingStation Get(int id)
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.FuelingStations.Find(id);
            }
        }

        public int Add(FuelingStation FuelingStation)
        {
            using (var ctx = new DBEFContext())
            {
                var obj = ctx.FuelingStations.Add(FuelingStation);
                ctx.SaveChanges();
                return obj.Entity.Id;
            }
        }

        public void Update(FuelingStation updeteFuelingStation)
        {
            using (var ctx = new DBEFContext())
            {
                var fuelingStation = ctx.FuelingStations.Find(updeteFuelingStation.Id);
                if (fuelingStation.Location != updeteFuelingStation.Location)
                {
                    fuelingStation.Location = updeteFuelingStation.Location;
                }
                if (fuelingStation.SupportedFuelTypes != updeteFuelingStation.SupportedFuelTypes)
                {
                    fuelingStation.SupportedFuelTypes = updeteFuelingStation.SupportedFuelTypes;
                }

                if (fuelingStation.NumberOfDepots != updeteFuelingStation.NumberOfDepots)
                {
                    fuelingStation.NumberOfDepots = updeteFuelingStation.NumberOfDepots;
                }

                if (fuelingStation.OtherTechnicalDetails != updeteFuelingStation.OtherTechnicalDetails)
                {
                    fuelingStation.OtherTechnicalDetails = updeteFuelingStation.OtherTechnicalDetails;
                }

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new DBEFContext())
            {
                ctx.FuelingStations.Remove(ctx.FuelingStations.Find(id));
                ctx.SaveChanges();
            }
        }
    }
}
