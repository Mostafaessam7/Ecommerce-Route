using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Model
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Name Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mail Required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min len 3")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
