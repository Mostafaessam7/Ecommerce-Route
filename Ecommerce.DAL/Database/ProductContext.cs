using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Database
{
	public class ProductContext : IdentityDbContext
    {

		public ProductContext(DbContextOptions<ProductContext> opts) : base(opts)
		{

		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Customer> Customer { get; set; }
		public DbSet<Order> Order { get; set; }
		public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<District> districts { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = . ; database= MyEcommerce ; Trusted_Connection=True ");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<OrderProduct>().HasKey(p => new { p.orderId, p.productId });
			modelBuilder.Entity<OrderProduct>().HasOne(a => a.order).WithMany(a => a.OrderProduct).HasForeignKey(a => a.orderId);
			modelBuilder.Entity<OrderProduct>().HasOne(a => a.Product).WithMany(a => a.OrderProduct).HasForeignKey(a => a.productId);
		}
	}
}
