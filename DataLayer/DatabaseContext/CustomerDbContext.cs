using System;
using Entities.Entitiler;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DatabaseContext
{
    public class CustomerDbContext: DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
           : base(options)
        {
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomerAdresses> CustomerAdresses { get; set; }
        public DbSet<CustomerDepartment> CustomerDepartment { get; set; }
    }
}

