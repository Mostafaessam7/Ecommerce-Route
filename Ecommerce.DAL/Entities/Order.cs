using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
	[Table("Order")]
	public class Order
	{
		public Order()
		{
			//this.orderTime= DateTime.Now;
			this.OrderProduct = new HashSet<OrderProduct>();

        }
		public int id { get; set; }
		public DateTime orderTime{ get; set; }

		[ForeignKey("Customer")]
		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }
		public ICollection<OrderProduct> OrderProduct { get; set; }
	}
}
