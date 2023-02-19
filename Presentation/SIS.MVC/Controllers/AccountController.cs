using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.ViewModels;
using SIS.Domain.Entities;
using SIS.Persistance.Contexts;

namespace SIS.MVC.Controllers
{
    public class AccountController : Controller
    {
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
		}

        /*public async Task<IActionResult> CreateRoles()
        {
            await _roleManager.CreateAsync(new() {Name="Admin"});
			await _roleManager.CreateAsync(new() { Name = "Student" });
			await _roleManager.CreateAsync(new() { Name = "Teacher" });

            return Content("Finished.");
		}*/

		/*public async Task<IActionResult> Setup()
        {
            await _roleManager.CreateAsync(new() { Name = "SuperAdmin" });

            AppUser user = new()
            {
                UserName = "Admin123",
                FirstName = "Super",
                LastName = "Admin"
            };

            await _userManager.CreateAsync(user, "Admin123");

            await _userManager.AddToRoleAsync(user, "SuperAdmin");

            return Ok("<h2>Setup finished.</h2>");
        }
*/

		[HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if(!ModelState.IsValid) return View(model);

            if((await _userManager.FindByNameAsync(model.UserName)) == null)
            {
                ModelState.AddModelError("", "Password or Username is invalid !");
                return View(model);
            }

            if(!(await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false)).Succeeded)
			{
				ModelState.AddModelError("", "Password or Username is invalid !");
				return View(model);
			}

			return RedirectToAction("index","home");
        }

        public async Task<IActionResult> MyProfile()
        {
            if (!User.Identity.IsAuthenticated) return NotFound();

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null) return NotFound();

            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("login");
        }
        
    }
}
