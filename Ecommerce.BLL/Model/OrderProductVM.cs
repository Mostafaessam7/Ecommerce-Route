using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Model
{
	public class OrderProductVM
	{
		public int orderId { get; set; }
		public Order order { get; set; }

		public int productId { get; set; }
		public Product Product { get; set; }
	}
}
