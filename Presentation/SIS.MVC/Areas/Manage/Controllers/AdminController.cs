using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Features.Commands.Admin.Create;
using SIS.Application.Features.Commands.Admin.UpdateAdmin;
using SIS.Application.Features.Queries.Admin.GetAll;
using SIS.Application.Validators.AdminCommandValidators;
using SIS.Domain.Entities;

namespace SIS.MVC.Areas.Manage.Controllers
{
    [Area(nameof(Manage))]
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;
        private readonly CreateAdminCommandValidator _createAdminCommandValidator;

        public AdminController(IMediator mediator, UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
            _createAdminCommandValidator = new CreateAdminCommandValidator();
        }

		public void ViewDataConfig(string title, string nav1, string nav2)
		{
			ViewData["title"] = title;
			ViewData["nav1"] = nav1;
			ViewData["nav2"] = nav2;
		}
		public async Task<IActionResult> Index(GetAllAdminQueryRequest request)
        {
            ViewDataConfig("Admin","Admin","Index");


            return View(await _mediator.Send(request));
        }

        public async Task<IActionResult> IndexGrid(GetAllAdminQueryRequest request)
        {
			ViewDataConfig("Admin", "Admin", "Index");

			return View(await _mediator.Send(request));
		}

        public IActionResult Create()
        {
			ViewDataConfig("Add New", "Admin", "Create");


			return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdminCommandRequest request)
        {
			ViewDataConfig("Add New", "Admin", "Create");

			if (!ModelState.IsValid) return View(request);

            var response = await _mediator.Send(request);

            if (!response.Success)
            {
                ModelState.AddModelError("", response.ErrorMessage);

                return View(request);
            }

            return RedirectToAction("index");
        }



        public async Task<IActionResult> Update(string id)
        {
			ViewDataConfig("Edit Admin", "Admin", "Update");


			AppUser user;

            user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            if (user == null) return NotFound();

            UpdateAdminCommandRequest request = new()
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.PhoneNumber,
                Adress = user.Adress,
                BirthDate = user.BirthDate,
                Email = user.Email,
                JobDescription = user.JobDescription,
                Gender = user.Gender
            };

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAdminCommandRequest request)
        {
			ViewDataConfig("Edit Admin", "Admin", "Update");

			if (!ModelState.IsValid) return View(request);

			var response = await _mediator.Send(request);

			if (!response.Success)
            {
				ModelState.AddModelError("", response.ErrorMessage);

				return View(request);
			}

			return RedirectToAction("index");
		}


        public async Task<IActionResult> Delete(string id)
        {
			AppUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id && (x.IsDeleted == false || x.IsDeleted == null));

            if(user is null) return NotFound();

            user.IsDeleted = true;
            IdentityResult response = await _userManager.UpdateAsync(user);

            if (!response.Succeeded)
                return BadRequest();

			return Ok();
        }


    }
}
