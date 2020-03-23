using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;



namespace ConsoleApp1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TestORM;Trusted_Connection=True;");
        }
    }
}
