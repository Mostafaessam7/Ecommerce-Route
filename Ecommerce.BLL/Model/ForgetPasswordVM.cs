using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Model
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "Mail Required")]
        [EmailAddress(ErrorMessage = "Enter Valid Mail")]
        public string Email { get; set; }
    }
}
