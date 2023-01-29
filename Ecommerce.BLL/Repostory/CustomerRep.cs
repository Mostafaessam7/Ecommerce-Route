using Ecommerce.BLL.Interfaces;
using Ecommerce.DAL.Database;
using Ecommerce.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.BLL.Repostory
{
	public class CustomerRep : ICustomerRep
	{
		private readonly ProductContext db;

		public CustomerRep(ProductContext db)
		{
			this.db = db;
		}

		public IEnumerable<Customer> GetAll()
		{
			var data = db.Customer.Select(a => a);
			return data;
		}

		public Customer GetProById(int id)
		{
			var data = db.Customer.Where(a=>a.id==id).FirstOrDefault();
			return data;
		}

		public void Create(Customer proVM)
		{
			db.Customer.Add(proVM);
			db.SaveChanges();
		}

		public void Update(Customer proVM)
		{
			db.Entry(proVM).State=EntityState.Modified;
			db.SaveChanges();
		}
		public void Delete(Customer proVM)
		{
			db.Customer.Remove(proVM);
			db.SaveChanges();
		}

        public IEnumerable<Product> ProductByCstId(int CstId)
        {
			var data = db.Customer.Where(a => a.id == CstId).Join(

				db.OrderProduct,

				a => a.id,
				b => b.order.CustomerId,

				(a, b) => new Product()
				{
					id = b.Product.id,
					name = b.Product.name,
					color = b.Product.color,
					Describ = b.Product.Describ,
					price = b.Product.price,
					size = b.Product.size,
					quantity = b.Product.quantity,
					productUser = b.Product.productUser
				}
				) ;
			return (data);
        }
    }
}
