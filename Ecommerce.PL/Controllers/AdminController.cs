using Ecommerce.BLL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.PL.Controllers
{
	public class AdminController : Controller
	{
		private readonly RoleManager<IdentityRole> roleManager;

		public AdminController(RoleManager<IdentityRole> roleManager)
		{
			this.roleManager = roleManager;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult CreateRole()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateRole(CreateRoleVM model)
		{
			if (ModelState.IsValid)
			{
				var data = new IdentityRole()
				{
					Name = model.RoleName

				};
				var res = await roleManager.CreateAsync(data);

				if (res.Succeeded)
				{
					return RedirectToAction("Index","Home");

				}
				else
				{
					foreach (var error in res.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}



			}
			return View();
		}

		public IActionResult EditRole()
		{
			return View();
		}

		public IActionResult DeleteRole()
		{
			return View();
		}
	}
}
