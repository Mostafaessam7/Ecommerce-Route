using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Model
{
    public class DistrictVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City city { get; set; }
    }
}
