using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Model
{
	public class OrderVM
	{
	
		public int id { get; set; }
		public DateTime orderTime { get; set; }

		public int CustomerId { get; set; }
		public Customer Customer { get; set; }

        public IEnumerable<int> ProductId { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }
	}
}
