using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo_Inventory.Data
{
	public static class InventoriesDbInitialiser
	{
		public static async Task SeedTestData(InventoriesDb context, 
											  IServiceProvider servies)
		{
			if (context.StockRequests.Any())
			{
				return;
			}

			var permissions = new List<Permission>
			{
				new Permission { Title = "High" },
				new Permission { Title = "Low" }
			};
			permissions.ForEach(p => context.Permissions.Add(p));
			await context.SaveChangesAsync();

			var staffs = new List<Staff>
			{
				new Staff { Permissions = permissions[0] },
				new Staff { Permissions = permissions[1] }
			};
			staffs.ForEach(s => context.Staffs.Add(s));
			await context.SaveChangesAsync();

			var products = new List<Product>
			{
				new Product { Name = "Shades", StockQuantity = 999 },
				new Product { Name = "Mug", StockQuantity = 1 }
			};
			products.ForEach(p => context.Products.Add(p));
			await context.SaveChangesAsync();

			var stockRequests = new List<StockRequest>
			{
				new StockRequest { Products = products[0], Staffs = staffs[0], Quantity = 9, ApprovalStatus = true },
				new StockRequest { Products = products[1], Staffs = staffs[0], Quantity = 18, ApprovalStatus = false }
			};
			stockRequests.ForEach(r => context.StockRequests.Add(r));
			await context.SaveChangesAsync();
		}
	}
}
