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
    public class TransactionRepository
    {
        public IEnumerable<Transaction> GetAll()
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.Transactions.Include(x => x.Customer).Include(x => x.Employee).ToList();
            }
        }

        public Transaction Get(int id)
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.Transactions.Include(x => x.Customer).Include(x => x.Employee).FirstOrDefault(x => x.Id == id);
            }
        }

        public int Add(Transaction Transaction)
        {
            using (var ctx = new DBEFContext())
            {
                var obj = ctx.Transactions.Add(Transaction);
                ctx.SaveChanges();
                return obj.Entity.Id;
            }
        }

        public void Update(Transaction updeteTransaction)
        {
            using (var ctx = new DBEFContext())
            {
                var transaction = ctx.Transactions.Find(updeteTransaction.Id);
                if (transaction.DateTime != updeteTransaction.DateTime)
                {
                    transaction.DateTime = updeteTransaction.DateTime;
                }
                if (transaction.Amount != updeteTransaction.Amount)
                {
                    transaction.Amount = updeteTransaction.Amount;
                }
                if (transaction.Quantity != updeteTransaction.Quantity)
                {
                    transaction.Quantity = updeteTransaction.Quantity;
                }
                if (transaction.OtherDetails != updeteTransaction.OtherDetails)
                {
                    transaction.OtherDetails = updeteTransaction.OtherDetails;
                }
                if (transaction.Customer != updeteTransaction.Customer)
                {
                    transaction.Customer = updeteTransaction.Customer;
                }
                if (transaction.Employee != updeteTransaction.Employee)
                {
                    transaction.Employee = updeteTransaction.Employee;
                }
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new DBEFContext())
            {
                ctx.Transactions.Remove(ctx.Transactions.Find(id));
                ctx.SaveChanges();
            }
        }
    }
}
