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
    public class SaleRepository
    {
        public IEnumerable<Sale> GetAll()
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.Sales.Include(x => x.Transaction).ToList();
            }
        }

        public Sale Get(int id)
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.Sales.Include(x => x.Transaction).FirstOrDefault(x => x.Id == id);
            }
        }

        public int Add(Sale Sale)
        {
            using (var ctx = new DBEFContext())
            {
                var obj = ctx.Sales.Add(Sale);
                ctx.SaveChanges();
                return obj.Entity.Id;
            }
        }

        public void Update(Sale updeteSale)
        {
            using (var ctx = new DBEFContext())
            {
                var sale = ctx.Sales.Find(updeteSale.Id);
                if (sale.SaleAmount != updeteSale.SaleAmount)
                {
                    sale.SaleAmount = updeteSale.SaleAmount;
                }
                if (sale.OtherSaleDetails != updeteSale.OtherSaleDetails)
                {
                    sale.OtherSaleDetails = updeteSale.OtherSaleDetails;
                }
                if (sale.Transaction != updeteSale.Transaction)
                {
                    sale.Transaction = updeteSale.Transaction;
                }
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new DBEFContext())
            {
                ctx.Sales.Remove(ctx.Sales.Find(id));
                ctx.SaveChanges();
            }
        }
    }
}
