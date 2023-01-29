using Ecommerce.BLL.Interfaces;
using Ecommerce.DAL.Database;
using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Repostory
{
	public class OrderProductRep : IOrderProductRep
	{
		private readonly ProductContext db;

		public OrderProductRep(ProductContext db)
		{
			this.db = db;
		}
		public void Create(int OrderId , int ProductId)
		{
			db.OrderProduct.Add(new OrderProduct() { orderId=OrderId , productId = ProductId});
			db.SaveChanges();
		}

		public void Delete(OrderProduct proVM)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<OrderProduct> GetAll()
		{
			throw new NotImplementedException();
		}

		public OrderProduct GetProById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
