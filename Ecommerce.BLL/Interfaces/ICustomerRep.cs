using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Interfaces
{
	public interface ICustomerRep
	{
		public void Create(Customer proVM);

		public Customer GetProById(int id);

		public IEnumerable<Customer> GetAll();

		public void Update(Customer proVM);
		public void Delete(Customer proVM);

		public IEnumerable<Product> ProductByCstId(int CstId);

    }
}
