using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.Features.Commands.TeacherCommand.CreateTeacher;
using SIS.Application.Features.Queries.TeacherQuery.GetAll;
using SIS.Application.Repositories.DepartmentRepository;
using SIS.Domain.Entities;
using System.Data;

namespace SIS.MVC.Areas.Manage.Controllers
{
	[Area(nameof(Manage))]
	[Authorize(Roles = "SuperAdmin,Admin")]
	public class TeacherController : Controller
	{
		private readonly IMediator _mediator;
		private readonly UserManager<AppUser> _userManager;
		private readonly IDepartmentReadRepository _departmentReadRepository;

		public TeacherController(IMediator mediator, UserManager<AppUser> userManager, 
			IDepartmentReadRepository departmentReadRepository)
		{
			_mediator = mediator;
			_userManager = userManager;
			_departmentReadRepository = departmentReadRepository;
		}

		public async Task<IActionResult> Index(GetAllTeacherQueryRequest request)
		{
			return View(await _mediator.Send(request));
		}

		public IActionResult Create()
		{
			ViewData["Departments"] = _departmentReadRepository.GetAll().ToList();
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateTeacherCommandRequest request)
		{
			ViewData["Departments"] = _departmentReadRepository.GetAll().ToList();
			if (!ModelState.IsValid) return View(request);

			var response = await _mediator.Send(request);

			if (!response.Success)
			{
				ModelState.AddModelError("", response.ErrorMessage);

				return View(request);
			}

			return RedirectToAction("index");

		}
	}
}
