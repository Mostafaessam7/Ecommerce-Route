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
    public class DistrictRep : IDistrictRep
    {
        private readonly ProductContext db;

        public DistrictRep(ProductContext db)
        {
            this.db = db;
        }
        public IEnumerable<District> getAll(int id)
        {
            var data =db.districts.Where(a=>a.CityId==id).ToList();
            return data;
        }
    }
}
