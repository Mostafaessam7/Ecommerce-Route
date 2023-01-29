using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
	[Table("OrderProduct")]
	public class OrderProduct
	{
        [ForeignKey("order")]
        public int orderId { get; set; }
		public Order order{ get; set; }

        [ForeignKey("Product")]
        public int productId { get; set; }
		public Product Product { get; set; }

	}
}
