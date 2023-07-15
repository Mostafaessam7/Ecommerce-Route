using Ecommerce.BLL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ecommerce.PL.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
		private readonly SignInManager<IdentityUser> signInManager;
		private readonly ILogger<AccountController> logger;

		public AccountController(UserManager<IdentityUser> userManager ,SignInManager<IdentityUser> signInManager,ILogger<AccountController> logger)
        {
            this.userManager = userManager;
			this.signInManager = signInManager;
			this.logger = logger;
		}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Register(RegisterVM model)
		{
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };

               var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
			return View(model);
		}


		public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
               var res=await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                if (res.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
				else
				{
                    ModelState.AddModelError("","UserName Or Password Invaled");
				}
			}
         
            return View();
        }
		public async Task<IActionResult> LogOut()
		{
           await signInManager.SignOutAsync();
            return RedirectToAction("Login");

		}


		public IActionResult ForgetPassword()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
		{
			if (ModelState.IsValid)
			{
				var user = await userManager.FindByEmailAsync(model.Email);

				if (user != null)
				{
					var token = await userManager.GeneratePasswordResetTokenAsync(user);

					var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);


					logger.Log(LogLevel.Warning, passwordResetLink);

					return RedirectToAction("ConfirmForgetPassword");
				}

				return View(model);


			}

			return View(model);
		}


		public IActionResult ConfirmForgetPassword()
        {
            return View();
        }

        public IActionResult ResetPassword( string Email,string Token)
        {
            if (Email==null || Token==null)
            {
                ModelState.AddModelError("", " InValid");
            }
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
		{
			if (ModelState.IsValid)
			{
				var user = await userManager.FindByEmailAsync(model.Email);

				if (user != null)
				{
					var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

					if (result.Succeeded)
					{
						return RedirectToAction("Login");
					}

					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}

					return View(model);
				}

				return RedirectToAction("Login");
			}

			return View(model);
		}

	}
}
