using System;
using dbCard.Domain.EFConfiguration;
using dbCard.Domain.Models;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = dbCardContextSettings.ConfigurationRoot.GetConnectionString("DefaultConnection");
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
            //modelBuilder.Entity<Customer>(entity =>
            //{
            //    entity.ToTable("Customers");

            //    entity.HasIndex(e => e.UserId)
            //        .HasName("UQ__Customer__1788CC4D4F091CB7")
            //        .IsUnique();

            //    entity.Property(e => e.DateOfBirth).HasColumnType("date");

            //    entity.Property(e => e.DateOfRegistration)
            //        .HasColumnType("date")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.FirstName)
            //        .IsRequired()
            //        .HasMaxLength(40);

            //    entity.Property(e => e.Gender)
            //        .IsRequired()
            //        .HasMaxLength(10);

            //    entity.Property(e => e.LastName)
            //        .IsRequired()
            //        .HasMaxLength(40);

            //    entity.HasOne(d => d.User)
            //        .WithOne(p => p.Customer)
            //        .HasForeignKey<Customer>(d => d.UserId)
            //        .HasConstraintName("FK__Customers__UserI__45F365D3");
            //});

            //modelBuilder.Entity<CustomersBalance>(entity =>
            //{
            //    entity.ToTable("CustomersBalance");
            //    entity.Property(e => e.AccumulatedAmount).HasColumnType("decimal(10, 2)");

            //    entity.Property(e => e.PaidAmount).HasColumnType("decimal(10, 2)");

            //    entity.Property(e => e.ResetDate).HasColumnType("datetime");

            //    entity.HasOne(d => d.Customer)
            //        .WithMany(p => p.CustomersBalances)
            //        .HasForeignKey(d => d.CustomerId)
            //        .HasConstraintName("FK__Customers__Custo__46E78A0C");

            //    entity.HasOne(d => d.Partner)
            //        .WithMany(p => p.CustomersBalances)
            //        .HasForeignKey(d => d.PartnerId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__Customers__Partn__2EDAF651");
            //});

            ////modelBuilder.Entity<FavoritePartner>(entity =>
            ////{
            ////    entity.HasOne(d => d.Customer)
            ////        .WithMany(p => p.FavoritePartners)
            ////        .HasForeignKey(d => d.CustomerId)
            ////        .OnDelete(DeleteBehavior.ClientSetNull)
            ////        .HasConstraintName("FK__FavoriteP__Custo__04E4BC85");

            ////    entity.HasOne(d => d.Partner)
            ////        .WithMany(p => p.FavoritePartners)
            ////        .HasForeignKey(d => d.PartnerId)
            ////        .HasConstraintName("FK__FavoriteP__Partn__22751F6C");
            ////});

            //modelBuilder.Entity<Filial>(entity =>
            //{
            //    entity.ToTable("Filials");
            //    entity.HasIndex(e => e.PhoneNumber)
            //        .HasName("UQ__Filials__85FB4E386E137F2D")
            //        .IsUnique();

            //    entity.Property(e => e.Address)
            //        .IsRequired()
            //        .HasMaxLength(40);

            //    entity.Property(e => e.PhoneNumber)
            //        .IsRequired()
            //        .HasMaxLength(15);

            //    entity.HasOne(d => d.Partner)
            //        .WithMany(p => p.Filials)
            //        .HasForeignKey(d => d.PartnerId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__Filials__Partner__72C60C4A");
            //});

            //modelBuilder.Entity<News>(entity =>
            //{
            //    entity.ToTable("News");
            //    entity.Property(e => e.Body)
            //        .IsRequired()
            //        .HasMaxLength(4000);

            //    entity.Property(e => e.DateOfCreation)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.ShortBody).HasMaxLength(100);

            //    entity.Property(e => e.Title)
            //        .IsRequired()
            //        .HasMaxLength(40);

            //    entity.HasOne(d => d.Partner)
            //        .WithMany(p => p.News)
            //        .HasForeignKey(d => d.PartnerId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__News__PartnerId__73BA3083");
            //});

            //modelBuilder.Entity<Partner>(entity =>
            //{
            //    entity.ToTable("Partners");
            //    entity.HasIndex(e => e.UserId)
            //        .HasName("UQ__Partners__1788CC4D82E8ECAA")
            //        .IsUnique();

            //    entity.Property(e => e.BirthdayDiscount).HasColumnType("decimal(3, 2)");

            //    entity.Property(e => e.Category)
            //        .IsRequired()
            //        .HasMaxLength(40)
            //        .HasDefaultValueSql("('UNIVERSAL')");

            //    entity.Property(e => e.DateOfRegistration)
            //        .HasColumnType("date")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(4000);

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(40);

            //    entity.Property(e => e.Rating).HasColumnType("decimal(2, 2)");

            //    entity.HasOne(d => d.User)
            //        .WithOne(p => p.Partner)
            //        .HasForeignKey<Partner>(d => d.UserId)
            //        .HasConstraintName("FK__Partners__UserId__4CA06362");
            //});

            //modelBuilder.Entity<PremiumDiscount>(entity =>
            //{
            //    entity.ToTable("PremiumDiscounts");
            //    entity.Property(e => e.AccumulationPercent).HasColumnType("decimal(2, 2)");

            //    entity.Property(e => e.DiscountPercent).HasColumnType("decimal(2, 2)");

            //    entity.Property(e => e.PriceOfDiscount).HasColumnType("decimal(4, 2)");

            //    entity.HasOne(d => d.Partner)
            //        .WithMany(p => p.PremiumDiscount)
            //        .HasForeignKey(d => d.PartnerId)
            //        .HasConstraintName("FK__PremiumDi__Partn__75A278F5");
            //});

            //modelBuilder.Entity<Review>(entity =>
            //{
            //    entity.ToTable("Reviews");
            //    entity.Property(e => e.Body)
            //        .IsRequired()
            //        .HasMaxLength(1000);

            //    entity.HasOne(d => d.AnswerReviewNavigation)
            //        .WithMany(p => p.InverseAnswerReviewNavigation)
            //        .HasForeignKey(d => d.AnswerReview)
            //        .HasConstraintName("FK__Reviews__AnswerR__76969D2E");

            //    entity.HasOne(d => d.Customer)
            //        .WithMany(p => p.Reviews)
            //        .HasForeignKey(d => d.CustomerId)
            //        .OnDelete(DeleteBehavior.SetNull)
            //        .HasConstraintName("FK__Reviews__Custome__4E88ABD4");

            //    entity.HasOne(d => d.Partner)
            //        .WithMany(p => p.Reviews)
            //        .HasForeignKey(d => d.PartnerId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__Reviews__Partner__787EE5A0");
            //});

            //modelBuilder.Entity<StandartDiscount>(entity =>
            //{
            //    entity.ToTable("StandartDiscounts");
            //    entity.Property(e => e.AmountOfDiscount).HasColumnType("decimal(4, 2)");

            //    entity.Property(e => e.DiscountPercent).HasColumnType("decimal(2, 2)");

            //    entity.HasOne(d => d.Partner)
            //        .WithMany(p => p.StandartDiscounts)
            //        .HasForeignKey(d => d.PartnerId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__StandartD__Partn__797309D9");
            //});

            //modelBuilder.Entity<Transaction>(entity =>
            //{
            //    entity.ToTable("Transactions");
            //    entity.Property(e => e.AccumulationAmount).HasColumnType("decimal(10, 2)");

            //    entity.Property(e => e.AllAmount).HasColumnType("decimal(10, 2)");

            //    entity.Property(e => e.AmountForPay).HasColumnType("decimal(10, 2)");

            //    entity.Property(e => e.Category)
            //        .IsRequired()
            //        .HasMaxLength(40);

            //    entity.Property(e => e.DiscountAmount).HasColumnType("decimal(10, 2)");

            //    entity.Property(e => e.FilialAddress)
            //        .IsRequired()
            //        .HasMaxLength(40);

            //    entity.Property(e => e.PartnerName)
            //        .IsRequired()
            //        .HasMaxLength(40);

            //    entity.HasOne(d => d.Customer)
            //        .WithMany(p => p.Transactions)
            //        .HasForeignKey(d => d.CustomerId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__Transacti__Custo__1DB06A4F");

            //    entity.HasOne(d => d.Filial)
            //        .WithMany(p => p.Transactions)
            //        .HasForeignKey(d => d.FilialId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__Transacti__Filia__1EA48E88");
            //});

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.ToTable("Users");
            //    entity.HasIndex(e => e.Email)
            //        .HasName("UQ__Users__A9D10534FDB9EF62")
            //        .IsUnique();

            //    entity.HasIndex(e => e.UserName)
            //        .HasName("UQ__Users__C9F2845668362305")
            //        .IsUnique();

            //    entity.Property(e => e.Email)
            //        .IsRequired()
            //        .HasMaxLength(40);

            //    entity.Property(e => e.Password)
            //        .IsRequired()
            //        .HasMaxLength(20);

            //    entity.Property(e => e.UserName)
            //        .IsRequired()
            //        .HasMaxLength(20);
            //});
        }
    }
}
