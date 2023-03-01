using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Features.Commands.AttendanceCommand.UpdateAttendance;
using SIS.Application.Features.Commands.UserCommand.UpdateUser;
using SIS.Application.Features.Commands.UserPasswordCommand.UserPasswordUpdate;
using SIS.Application.Features.Queries.AttendanceQuery.GetAll;
using SIS.Application.Repositories.AttendanceRepository;
using SIS.Application.Repositories.GroupRepository;
using SIS.Application.Repositories.LessonEventRepository;
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
		private readonly IMediator _mediator;
		private readonly ILessonEventReadRepository _lessonEventReadRepository;
		private readonly IGroupReadRepository _groupReadRepository;

		public AccountController(
            UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            SignInManager<AppUser> signInManager,
            IMediator mediator,
            ILessonEventReadRepository lessonEventReadRepository,
            IGroupReadRepository groupReadRepository)
        {
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_mediator = mediator;
			_lessonEventReadRepository = lessonEventReadRepository;
			_groupReadRepository = groupReadRepository;
		}


		[HttpGet]
        public async Task<IActionResult> Login()
        {
            // Check seed data
            AppUser superadmin = await _userManager.FindByNameAsync("rufettalib");

			if (superadmin != null)
            {
                IList<string> user_roles = await _userManager.GetRolesAsync(superadmin);

                if (user_roles.Contains("SuperAdmin"))
                    return View();
                
                var result = await _userManager.AddToRoleAsync(superadmin, "SuperAdmin");

                if(! result.Succeeded)
                    return View(nameof(ErrorPage));
			}
            else
                return View(nameof(ErrorPage));
                
            
            return View();
        }

        public IActionResult ErrorPage()
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

        public async Task<IActionResult> ChangePassword()
        {
			if (!User.Identity.IsAuthenticated) return NotFound();

			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

			if (user == null) return NotFound();

			UserPasswordUpdateCommandRequest request = new()
			{
				OldPassword = null,
				NewPassword = null,
				NewPasswordConfirm = null
			};

			return View(request);
		}

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserPasswordUpdateCommandRequest request)
        {
			if (!ModelState.IsValid) return View(request);

			var response = await _mediator.Send(request);

			if (!response.Success)
			{
				ModelState.AddModelError("", response.ErrorMessage);

				return View(request);
			}

            return RedirectToAction(nameof(MyProfile));
		}


        public async Task<IActionResult> MyProfile()
        {
            if (!User.Identity.IsAuthenticated) return NotFound();

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null) return NotFound();

            UpdateUserCommandRequest request = new()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Adress = user.Adress,
                Phone = user.PhoneNumber,
                BirthDate = user.BirthDate,
                Description= user.Description,
                JobDescription= user.JobDescription,
                ImageSrc= user.ImageSrc
            };

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> MyProfile(UpdateUserCommandRequest request)
        {
			if (!ModelState.IsValid) return View(request);

			var response = await _mediator.Send(request);

			if (!response.Success)
			{
				ModelState.AddModelError("", response.ErrorMessage);

				return View(request);
			}

			
            return RedirectToAction(nameof(MyProfile));
        }

        public async Task<IActionResult> Attendances(GetAllAttendanceQueryRequest request)
        {
			ViewData["NoLesson"] = false;
			var response = await _mediator.Send(request);

            if (response.Attendances is null)
            {
                ViewData["NoLesson"] = true;
                return View();
            }
			
			return View(new UpdateAttendanceCommandRequest
            {
                Attendances = response?.Attendances,
                LessonId = response?.LessonId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Attendances(UpdateAttendanceCommandRequest request)
        {
            await _mediator.Send(request);			

            return RedirectToAction("TimeTable");
        }

        public async Task<IActionResult> TimeTable()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return BadRequest();


            string username = HttpContext.User.Identity.Name;
            AppUser? user = await _userManager.Users
                .Where(x => x.IsDeleted == false && x.UserName == username)
                .Include(x => x.Groups)
                .ThenInclude(x => x.LessonEvents)
                .ThenInclude(x => x.Subject)
                .FirstOrDefaultAsync();

            if(HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("SuperAdmin"))
            {
                return RedirectToAction("myprofile");
            }


            if (user == null) return NotFound();

            List<LessonEvent> events = new();

            user.Groups.Where(x => x.IsDeleted == false).ToList()
                .ForEach(x => 
                events.AddRange(
                    x.LessonEvents.Where(e => e.IsDeleted == false).ToList() 
                    ) 
                );

			return View(events);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("login");
        }
        
    }
}
