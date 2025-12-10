using DEMO2_MILKTEA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MILKTEASHOP.Models
{
    public partial class TraSuaDbContext : DbContext
    {
        public TraSuaDbContext()
        {
        }

        public TraSuaDbContext(DbContextOptions<TraSuaDbContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Topping> Toppings { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderDetailTopping> OrderDetailToppings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-TQ4TILQ\\SQLEXPRESS;Database=TraSuaDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}