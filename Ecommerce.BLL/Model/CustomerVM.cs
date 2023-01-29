using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Model
{
	public class CustomerVM
	{
		public int id { get; set; }
		public string name { get; set; }
		public string address { get; set; }
		public string phone { get; set; }

		public int orderId { get; set; }
		public Order order { get; set; }
	}
}
