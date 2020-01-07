using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThAmCo_Inventory.Data
{
	public class InventoriesDb : DbContext
	{
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<Staff> Staffs { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<StockRequest> StockRequests { get; set; }

		public InventoriesDb(DbContextOptions<InventoriesDb> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Permission>(x =>
			{
				x.Property(i => i.Title).IsRequired();
			});

			modelBuilder.Entity<Staff>(x =>
			{
				x.HasOne(t => t.Permissions).WithMany()
											.HasForeignKey(t => t.Id)
											.IsRequired();
			});

			modelBuilder.Entity<Product>(x =>
			{
				x.Property(p => p.Name).IsRequired();
				x.Property(p => p.StockQuantity).IsRequired();
			});

			modelBuilder.Entity<StockRequest>(x =>
			{
				x.Property(s => s.Quantity).IsRequired();
				x.Property(s => s.ApprovalStatus).IsRequired();
				x.HasOne(s => s.Products).WithMany()
										 .HasForeignKey(s => s.ProductId)
										 .IsRequired();
				x.HasOne(s => s.Staffs).WithMany()
										.HasForeignKey(s => s.StaffId)
										.IsRequired();
			});
		}
	}
}