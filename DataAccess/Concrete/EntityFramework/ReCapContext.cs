using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCapProject;Trusted_Connection=True");
        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User>  Users {get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<CustomerCreditCard> CustomerCreditCard { get; set; }
    }
}
