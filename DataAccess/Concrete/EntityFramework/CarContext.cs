﻿using Core.Entities.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
  public   class CarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-JEQ1504\SQLEXPRESS;Database=Cars;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors{ get; set; }
        public DbSet<Brand>Brands{ get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<CarImages> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

         public DbSet<Payment> Payments { get; set; }
         public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
