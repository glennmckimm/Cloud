using System;
using System.Collections.Generic;
using System.Text;

namespace ThAmCo_Inventory.Data
{
	public class StockRequest
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int StaffId { get; set; }
		public int Quantity { get; set; }
		public Boolean ApprovalStatus { get; set; }

		public Product Products { get; set; }
		public Staff Staffs { get; set; }
	}
}
