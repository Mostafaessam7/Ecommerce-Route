using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    [Table("Country")]
    public class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
