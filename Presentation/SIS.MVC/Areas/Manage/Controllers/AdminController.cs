using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Features.Commands.Admin.Create;
using SIS.Application.Features.Commands.Admin.CreateAdmin;
using SIS.Application.Features.Commands.Admin.UpdateAdmin;
using SIS.Application.Features.Queries.Admin.GetAll;
using SIS.Application.Validators.AdminCommandValidators;
using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        public async Task<IActionResult> Index(GetAllAdminQueryRequest request)
        {   
            return View(await _mediator.Send(request));
        }

        public async Task<IActionResult> IndexGrid(GetAllAdminQueryRequest request)
        {
            return View(await _mediator.Send(request));
		}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdminCommandRequest request)
        {
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
