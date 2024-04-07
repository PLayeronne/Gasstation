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
    public class OrderRepository
    {
        public IEnumerable<Order> GetAll()
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.Orders.Include(x => x.Customer).ToList();
            }
        }

        public Order Get(int id)
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.Orders.Include(x => x.Customer).FirstOrDefault(x => x.Id == id);
            }
        }

        public int Add(Order Order)
        {
            using (var ctx = new DBEFContext())
            {
                var obj = ctx.Orders.Add(Order);
                ctx.SaveChanges();
                return obj.Entity.Id;
            }
        }

        public void Update(Order updeteOrder)
        {
            using (var ctx = new DBEFContext())
            {
                var order = ctx.Orders.Find(updeteOrder.Id);
                if (order.OrderDateTime != updeteOrder.OrderDateTime)
                {
                    order.OrderDateTime = updeteOrder.OrderDateTime;
                }
                if (order.TotalAmount != updeteOrder.TotalAmount)
                {
                    order.TotalAmount = updeteOrder.TotalAmount;
                }
                if (order.OrderStatus != updeteOrder.OrderStatus)
                {
                    order.OrderStatus = updeteOrder.OrderStatus;
                }
                if (order.Customer != updeteOrder.Customer)
                {
                    order.Customer = updeteOrder.Customer;
                }
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new DBEFContext())
            {
                ctx.Orders.Remove(ctx.Orders.Find(id));
                ctx.SaveChanges();
            }
        }
    }
}
