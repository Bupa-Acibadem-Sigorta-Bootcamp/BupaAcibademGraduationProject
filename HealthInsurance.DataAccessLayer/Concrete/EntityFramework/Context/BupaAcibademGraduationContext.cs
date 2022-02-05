using System;
using HealthInsurance.EntityLayer.Concrete.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace HealthInsurance.DataAccessLayer.Concrete.EntityFramework.Context
{
    public partial class BupaAcibademGraduationContext : DbContext
    {
        private readonly IConfiguration configuration;
        public BupaAcibademGraduationContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public BupaAcibademGraduationContext(DbContextOptions<BupaAcibademGraduationContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<CorporateCostemer> CorporateCostemers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<IndividualCustomer> IndividualCustomers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(useLazyLoadingProxies: true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Card>(entity =>
            {
                entity.Property(e => e.CardHolderFirstNameLastName).HasMaxLength(50);

                entity.Property(e => e.CardValidationValue).HasMaxLength(10);

                entity.Property(e => e.CreditCardNumber).HasMaxLength(20);

                entity.Property(e => e.ValidThru).HasMaxLength(10);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Cards_Customers");
            });

            modelBuilder.Entity<CorporateCostemer>(entity =>
            {
                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.TaxNumber).HasMaxLength(11);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CorporateCostemers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CorporateCostemers_Customers");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<IndividualCustomer>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasMaxLength(10);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.IdentityNumber).HasMaxLength(11);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.IndividualCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IndividualCustomers_Customers");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderDate).HasMaxLength(10);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Orders_Products");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.InstallmentType).HasMaxLength(10);

                entity.Property(e => e.PaymentDate).HasMaxLength(10);

                entity.Property(e => e.PaymentType).HasMaxLength(25);

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CardId)
                    .HasConstraintName("FK_Payments_Cards");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Payments_Customers");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
