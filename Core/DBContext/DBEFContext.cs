using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DBContext
{
    public class DBEFContext : DbContext
    {
        public DBEFContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<FuelingStation> FuelingStations => Set<FuelingStation>();
        public DbSet<FuelInventory> FuelInventories => Set<FuelInventory>();
        public DbSet<FuelType> FuelTypes => Set<FuelType>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=gasStation;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
