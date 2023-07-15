using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Model
{
	public class CreateRoleVM
	{
		[Required]
		public string RoleName { get; set; }

	}
}
