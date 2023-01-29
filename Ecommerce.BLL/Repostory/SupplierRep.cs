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
    public class SupplierRep : ISupplierRep
    {
        private readonly ProductContext db;

        public SupplierRep(ProductContext db)
        {
            this.db = db;
        }
        public void Create(Supplier model)
        {
            db.suppliers.Add(model);
            db.SaveChanges(); 

        }

        public void Delete(Supplier model)
        {

            db.suppliers.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<Supplier> GetAll()
        {
            return (db.suppliers.Include(a=>a.district).ToList());
        }

        public Supplier getById(int id)
        {
            var data = db.suppliers.Include(a => a.district).Where(a => a.id == id).FirstOrDefault();
            return data;
        }

    

        public void Update(Supplier model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
