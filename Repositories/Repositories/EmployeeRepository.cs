using Core.DBContext;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class EmployeeRepository
    {
        public IEnumerable<Employee> GetAll()
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.Employees.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (var ctx = new DBEFContext())
            {
                return ctx.Employees.Find(id);
            }
        }

        public int Add(Employee Employee)
        {
            using (var ctx = new DBEFContext())
            {
                var obj = ctx.Employees.Add(Employee);
                ctx.SaveChanges();
                return obj.Entity.Id;
            }
        }

        public void Update(Employee updeteEmployee)
        {
            using (var ctx = new DBEFContext())
            {
                var employee = ctx.Employees.Find(updeteEmployee.Id);
                if (employee.FullName != updeteEmployee.FullName)
                {
                    employee.FullName = updeteEmployee.FullName;
                }
                if (employee.Position != updeteEmployee.Position)
                {
                    employee.Position = updeteEmployee.Position;
                }

                if (employee.ContactInformation != updeteEmployee.ContactInformation)
                {
                    employee.ContactInformation = updeteEmployee.ContactInformation;
                }

                if (employee.OtherDetails != updeteEmployee.OtherDetails)
                {
                    employee.OtherDetails = updeteEmployee.OtherDetails;
                }

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new DBEFContext())
            {
                ctx.Employees.Remove(ctx.Employees.Find(id));
                ctx.SaveChanges();
            }
        }
    }
}
