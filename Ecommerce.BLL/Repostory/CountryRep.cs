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
    public class CountryRep : ICountryRep
    {
        private readonly ProductContext db;

        public CountryRep(ProductContext db)
        {
            this.db = db;
        }
        public IEnumerable<Country> getAll()
        {
            var data = db.Countries.ToList();
            return data;
        }
    }
}
