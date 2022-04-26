using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkTest.Models;

namespace EntityFrameworkTest.DataAccess
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-GNU3H6C;Database=Company;Integrated Security=true;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
