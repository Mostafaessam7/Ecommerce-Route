using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Model
{
    public class ProductVM
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string color { get; set; }
        [Required]
        public string size { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public int quantity { get; set; }
        public string productUser { get; set; }
        [Required]
        public string Describ { get; set; }

		public ICollection<OrderProduct> OrderProduct { get; set; }

	}
}
