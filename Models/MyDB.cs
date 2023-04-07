using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoAnLTWeb.Models
{
    public partial class MyDB : DbContext
    {
        public MyDB()
            : base("name=MyDB")
        {
        }

        public virtual DbSet<Loai> Loais { get; set; }
        public virtual DbSet<Output> Outputs { get; set; }
        public virtual DbSet<OutputDetail> OutputDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Output>()
                .Property(e => e.giaohang)
                /*.HasPrecision(19, 4)*/;

            modelBuilder.Entity<Output>()
                .Property(e => e.thanhtoan)
                /*.HasPrecision(19, 4)*/;

            modelBuilder.Entity<OutputDetail>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price_Sell)
                .HasPrecision(19, 4);
        }
    }
}
