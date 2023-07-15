using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Model
{
    public class CityVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public int CountyId { get; set; }

        [ForeignKey("CountyId")]
        public virtual Country country { get; set; }
        public virtual ICollection<District> District { get; set; }

    }
}
