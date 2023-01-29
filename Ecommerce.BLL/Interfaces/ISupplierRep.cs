using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Interfaces
{
    public interface ISupplierRep
    {
        public void Create(Supplier model);
        public void Delete(Supplier model);
        public void Update(Supplier model);

        public Supplier getById(int id);
        public IEnumerable<Supplier> GetAll();
    }
}
