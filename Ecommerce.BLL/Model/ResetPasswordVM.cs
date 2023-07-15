﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ecommerce.BLL.Model
{
	public class ResetPasswordVM
	{
		[Required(ErrorMessage = "Mail Required")]
		[EmailAddress(ErrorMessage = "Enter Valid Mail")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password Required")]
		[DataType(DataType.Password)]
		[MinLength(3, ErrorMessage = "Min len 3")]
		public string Password { get; set; }

		[Required(ErrorMessage = "ConfirmPassword Required")]
		[DataType(DataType.Password)]
		[MinLength(3, ErrorMessage = "Min len 3")]
		[Compare("Password", ErrorMessage = "Not Matching")]
		[Display(Name = "Confirm Password")]
		public string ConfirmPassword { get; set; }

		[Required]
		public string Token { get; set; }
	}
}
