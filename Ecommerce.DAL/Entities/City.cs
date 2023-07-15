using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    [Table("City")]
    public class City
    {
        public City()
        {
            District = new HashSet<District>();
        }
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int CountyId { get; set; }

        [ForeignKey("CountyId")]
        public virtual Country country { get; set; }
        public virtual ICollection<District> District { get; set; }

    }
}
