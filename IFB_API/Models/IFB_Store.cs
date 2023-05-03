using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace IFB_API.Models
{
    public partial class IFB_Store : DbContext
    {
        public IFB_Store()
            : base("name=IFB_Store")
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .Property(e => e.UPC)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Item>()
                .Property(e => e.SKU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Item>()
                .Property(e => e.On_Hand)
                .HasPrecision(5, 0);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderItem>()
                .Property(e => e.OrderId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);
        }
    }
}
