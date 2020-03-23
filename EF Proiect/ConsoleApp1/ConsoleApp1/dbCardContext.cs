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

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<CustomersBalance> CustomersBalance { get; set; }
        public virtual DbSet<FavoritePartners> FavoritePartners { get; set; }
        public virtual DbSet<Filials> Filials { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Partners> Partners { get; set; }
        public virtual DbSet<PremiumDiscount> PremiumDiscount { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
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
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__Customer__1788CC4D4F091CB7")
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

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Customers)
                    .HasForeignKey<Customers>(d => d.UserId)
                    .HasConstraintName("FK__Customers__UserI__45F365D3");
            });

            modelBuilder.Entity<CustomersBalance>(entity =>
            {
                entity.Property(e => e.AccumulatedAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ResetDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomersBalance)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Customers__Custo__46E78A0C");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.CustomersBalance)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customers__Partn__2EDAF651");
            });

            modelBuilder.Entity<FavoritePartners>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.FavoritePartners)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FavoriteP__Custo__04E4BC85");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.FavoritePartners)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK__FavoriteP__Partn__22751F6C");
            });

            modelBuilder.Entity<Filials>(entity =>
            {
                entity.HasIndex(e => e.PhoneNumber)
                    .HasName("UQ__Filials__85FB4E386E137F2D")
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
                    .HasConstraintName("FK__Filials__Partner__72C60C4A");
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
                    .HasConstraintName("FK__News__PartnerId__73BA3083");
            });

            modelBuilder.Entity<Partners>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__Partners__1788CC4D82E8ECAA")
                    .IsUnique();

                entity.Property(e => e.BirthdayDiscount).HasColumnType("decimal(3, 2)");

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
                    .HasConstraintName("FK__Partners__UserId__4CA06362");
            });

            modelBuilder.Entity<PremiumDiscount>(entity =>
            {
                entity.Property(e => e.AccumulationPercent).HasColumnType("decimal(2, 2)");

                entity.Property(e => e.DiscountPercent).HasColumnType("decimal(2, 2)");

                entity.Property(e => e.PriceOfDiscount).HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.PremiumDiscount)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK__PremiumDi__Partn__75A278F5");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.AnswerReviewNavigation)
                    .WithMany(p => p.InverseAnswerReviewNavigation)
                    .HasForeignKey(d => d.AnswerReview)
                    .HasConstraintName("FK__Reviews__AnswerR__76969D2E");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Reviews__Custome__4E88ABD4");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reviews__Partner__787EE5A0");
            });

            modelBuilder.Entity<StandartDiscount>(entity =>
            {
                entity.Property(e => e.AmountOfDiscount).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.DiscountPercent).HasColumnType("decimal(2, 2)");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.StandartDiscount)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StandartD__Partn__797309D9");
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
                    .HasConstraintName("FK__Transacti__Custo__1DB06A4F");

                entity.HasOne(d => d.Filial)
                    .WithMany(p => p.TransactionHistory)
                    .HasForeignKey(d => d.FilialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Filia__1EA48E88");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__A9D10534FDB9EF62")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Users__C9F2845668362305")
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
