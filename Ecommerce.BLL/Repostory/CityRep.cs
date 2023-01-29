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
    public class CityRep : ICityRep
    {
        private readonly ProductContext db;

        public CityRep(ProductContext db)
        {
            this.db = db;
        }
        public IEnumerable<City> getAll(int id)
        {
            var data = db.cities.Where(a => a.CountyId == id).ToList();
            return data;
        }

    }
}
