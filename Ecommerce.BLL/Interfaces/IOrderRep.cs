using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Interfaces
{
	public interface IOrderRep
	{
		public int Create(Order proVM);

		public Order GetProById(int id);

		public IEnumerable<Order> GetAll();

		public void Update(Order proVM);
		public void Delete(Order proVM);

		public int count();
	}
}
