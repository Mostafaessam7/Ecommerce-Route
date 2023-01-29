using Ecommerce.BLL.Interfaces;
using Ecommerce.DAL.Database;
using Ecommerce.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Repostory
{
	public class OrderRep : IOrderRep
	{
		private readonly ProductContext db;

		public OrderRep(ProductContext db)
		{
			this.db = db;
		}


		public IEnumerable<Order> GetAll()
		{
			var data = db.Order
				.Include(a=>a.Customer)
				.Include(a=>a.OrderProduct)
				.ThenInclude(a=>a.Product).Select(a => a);
			return data;
				
	    }

		public Order GetProById(int id)
		{
			var data = db.Order.Include(m=>m.Customer).Where(a=>a.id==id).FirstOrDefault();
			return data;
		}
		public int Create(Order proVM)
		{
			db.Order.Add(proVM);
			db.SaveChanges();
			return proVM.id;

		}
		public void Update(Order proVM)
		{
			throw new NotImplementedException();
		}


		public void Delete(Order proVM)
		{
			db.Order.Remove(proVM);
			db.SaveChanges();

		}

        public int count()
        {
			return db.Order.Count();
        }
    }
}
