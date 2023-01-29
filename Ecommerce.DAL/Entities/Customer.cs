using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
	[Table("Customer")]
	public class Customer
	{
		public int id { get; set; }
		public string name { get; set; }
		public string address { get; set; }
		public string phone { get; set; }

		//[ForeignKey("order")]
		//public Nullable<int> orderId{ get; set; }
		public virtual Order order{ get; set; }
	}
}
