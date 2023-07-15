using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Model
{
    public class CountryVM
    {
        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
