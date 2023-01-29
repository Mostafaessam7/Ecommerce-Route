using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Interfaces
{
	public interface IOrderProductRep
	{
		public void Create(int OrderId, int ProductId);

        public OrderProduct GetProById(int id);

		public IEnumerable<OrderProduct> GetAll();

		//public void Update(OrderProduct proVM);
		public void Delete(OrderProduct proVM);
	}
}
