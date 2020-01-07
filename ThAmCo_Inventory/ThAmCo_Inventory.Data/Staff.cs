using System;
using System.Collections.Generic;
using System.Text;

namespace ThAmCo_Inventory.Data
{
	public class Staff
	{
		public int Id { get; set; }
		public int PermissionsId { get; set; }

		public Permission Permissions { get; set; }
	}
}
