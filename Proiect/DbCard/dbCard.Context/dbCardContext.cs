using System;
using dbCard.Domain.EFConfiguration;
using dbCard.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace dbCard.Context
{
    public class dbCardContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomersBalance> CustomersBalances { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<StandartDiscount> StandartDiscounts { get; set; }
        public DbSet<PremiumDiscount> PremiumDiscounts { get; set; }
        public DbSet<Filial> Filials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public dbCardContext()
        {
        }
        public dbCardContext(DbContextOptions<dbCardContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =  dbCardSettings.ConfigurationRoot.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new CustomersBalanceConfig());
            modelBuilder.ApplyConfiguration(new FilialConfig());
            modelBuilder.ApplyConfiguration(new NewsConfig());
            modelBuilder.ApplyConfiguration(new PartnerConfig());
            modelBuilder.ApplyConfiguration(new PremiumDiscountConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());
            modelBuilder.ApplyConfiguration(new StandartDiscountConfig());
            modelBuilder.ApplyConfiguration(new TransactionConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());

        }
    }
}
