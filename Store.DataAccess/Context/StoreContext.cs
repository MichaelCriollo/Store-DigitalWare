using Store.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.Context
{
    public partial class StoreContext : DbContext
    {
        public StoreContext()
            : base("name=StoreContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<DetailBill> DetailBills { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSize> ProductSizes { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<SizeTypeProduct> SizeTypeProducts { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<TypeProduct> TypeProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            modelBuilder.Entity<Bill>()
                  .Property(e => e.TotalPrice)
                  .HasPrecision(18, 0);

            modelBuilder.Entity<Bill>()
                .HasMany(e => e.DetailBills)
                .WithRequired(e => e.Bill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.MobilePhone)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Color)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DetailBill>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Gender>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Gender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Reference)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.PriceUnit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.DetailBills)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductSizes)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Size>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Size>()
                .HasMany(e => e.ProductSizes)
                .WithRequired(e => e.Size)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Size>()
                .HasMany(e => e.SizeTypeProducts)
                .WithRequired(e => e.Size)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.State)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeProduct>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TypeProduct>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.TypeProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeProduct>()
                .HasMany(e => e.SizeTypeProducts)
                .WithRequired(e => e.TypeProduct)
                .WillCascadeOnDelete(false);
        }
    }
}
