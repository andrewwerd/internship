using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp1
{
    public partial class dbCardContext : DbContext
    {
        public dbCardContext()
        {
        }

        public dbCardContext(DbContextOptions<dbCardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BirthdayDiscount> BirthdayDiscount { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<CustomersBalance> CustomersBalance { get; set; }
        public virtual DbSet<FavoritePartners> FavoritePartners { get; set; }
        public virtual DbSet<Filials> Filials { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Partners> Partners { get; set; }
        public virtual DbSet<PremiumCustomers> PremiumCustomers { get; set; }
        public virtual DbSet<PremiumDiscount> PremiumDiscount { get; set; }
        public virtual DbSet<Rewiews> Rewiews { get; set; }
        public virtual DbSet<StandartDiscount> StandartDiscount { get; set; }
        public virtual DbSet<TransactionHistory> TransactionHistory { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dbCard;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BirthdayDiscount>(entity =>
            {
                entity.Property(e => e.DiscountPercent).HasColumnType("decimal(2, 2)");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.BirthdayDiscount)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK__BirthdayD__Partn__5812160E");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__Customer__1788CC4DC9976E5E")
                    .IsUnique();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DateOfRegistration)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.IsPremium).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Customers)
                    .HasForeignKey<Customers>(d => d.UserId)
                    .HasConstraintName("FK__Customers__UserI__2B3F6F97");
            });

            modelBuilder.Entity<CustomersBalance>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomersBalance)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Customers__Custo__3F466844");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.CustomersBalance)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customers__Disco__4F7CD00D");
            });

            modelBuilder.Entity<FavoritePartners>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.FavoritePartners)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FavoriteP__Custo__3A81B327");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.FavoritePartners)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FavoriteP__Partn__3B75D760");
            });

            modelBuilder.Entity<Filials>(entity =>
            {
                entity.HasIndex(e => e.PhoneNumber)
                    .HasName("UQ__Filials__85FB4E389AEDA3A8")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Filials)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Filials__Partner__5BE2A6F2");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.DateOfCreation)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShortBody).HasMaxLength(100);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__News__PartnerId__5EBF139D");
            });

            modelBuilder.Entity<Partners>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Partners__737584F6C229528E")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__Partners__1788CC4DF29C39CE")
                    .IsUnique();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('UNIVERSAL')");

                entity.Property(e => e.DateOfRegistration)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Rating).HasColumnType("decimal(2, 2)");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Partners)
                    .HasForeignKey<Partners>(d => d.UserId)
                    .HasConstraintName("FK__Partners__UserId__32E0915F");
            });

            modelBuilder.Entity<PremiumCustomers>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PremiumCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PremiumCu__Custo__45F365D3");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.PremiumCustomers)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PremiumCu__Partn__46E78A0C");
            });

            modelBuilder.Entity<PremiumDiscount>(entity =>
            {
                entity.Property(e => e.AccumulationPercent).HasColumnType("decimal(2, 2)");

                entity.Property(e => e.DiscountPercent).HasColumnType("decimal(2, 2)");

                entity.Property(e => e.PriceOfDiscount).HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.PremiumDiscount)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK__PremiumDi__Partn__4CA06362");
            });

            modelBuilder.Entity<Rewiews>(entity =>
            {
                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.AnswerRewiewNavigation)
                    .WithMany(p => p.InverseAnswerRewiewNavigation)
                    .HasForeignKey(d => d.AnswerRewiew)
                    .HasConstraintName("FK__Rewiews__AnswerR__75A278F5");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Rewiews)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Rewiews__Custome__76969D2E");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Rewiews)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rewiews__Partner__778AC167");
            });

            modelBuilder.Entity<StandartDiscount>(entity =>
            {
                entity.Property(e => e.AmountOfDiscount).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.DiscountPercent).HasColumnType("decimal(2, 2)");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.StandartDiscount)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StandartD__Partn__5441852A");
            });

            modelBuilder.Entity<TransactionHistory>(entity =>
            {
                entity.Property(e => e.AccumulationAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.AllAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.AmountForPay).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FilialAddress)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.PartnerName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TransactionHistory)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Custo__7A672E12");

                entity.HasOne(d => d.Filial)
                    .WithMany(p => p.TransactionHistory)
                    .HasForeignKey(d => d.FilialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Filia__7B5B524B");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__A9D10534DCD92106")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Users__C9F2845692B3557E")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
