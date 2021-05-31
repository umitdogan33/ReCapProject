using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReCapProject;Trusted_Connection=True");
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarImage>().ToTable("CarImages");
            modelBuilder.Entity<CarImage>().HasKey(x=> x.Id);

            modelBuilder.Entity<CarImage>().Property(x=> x.Id).HasColumnName("Id");
            modelBuilder.Entity<CarImage>().Property(x => x.CarId).HasColumnName("CarId");
            modelBuilder.Entity<CarImage>().Property(x => x.ImagePath).HasColumnName("ImagePath");
            modelBuilder.Entity<CarImage>().Property(x => x.Date_).HasColumnName("Date_");
        }
    }
}
