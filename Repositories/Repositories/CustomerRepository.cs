using Core.DBContext;
using Core.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repositories.Repositories
{
    public class CustomerRepository
    {
        public IEnumerable<Customer> GetAll()
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.Customers.ToList();
            }
        }

        public Customer Get(int id)
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.Customers.Find(id);
            }
        }

        public int Add(Customer Customer)
        {
            using (var ctx = new DBEFContext())
            {
                var obj = ctx.Customers.Add(Customer);
                ctx.SaveChanges();
                return obj.Entity.Id;
            }
        }

        public void Update(Customer updeteCustomer)
        {
            using (var ctx = new DBEFContext())
            {
                var customer = ctx.Customers.Find(updeteCustomer.Id);
                if (customer.FullName != updeteCustomer.FullName)
                {
                    customer.FullName = updeteCustomer.FullName;
                }

                if (customer.ContactInformation != updeteCustomer.ContactInformation)
                {
                    customer.ContactInformation = updeteCustomer.ContactInformation;
                }

                if (customer.OtherDetails != updeteCustomer.OtherDetails)
                {
                    customer.OtherDetails = updeteCustomer.OtherDetails;
                }

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new DBEFContext())
            {
                ctx.Customers.Remove(ctx.Customers.Find(id));
                ctx.SaveChanges();
            }
        }
    }
}

