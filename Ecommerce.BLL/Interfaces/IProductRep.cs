using Ecommerce.BLL.Model;
using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Interfaces
{
    public interface IProductRep
    {

        public Product GetProById(int id);

        public IEnumerable<Product> GetAll();

        public void Create(Product proVM);
        public void Update(Product proVM);
        public void Delete(Product proVM);
        



    }
}
