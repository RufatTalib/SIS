using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.Features.Commands.StudentCommand.CreateStudent;
using SIS.Application.Repositories.DepartmentRepository;
using SIS.Application.Repositories.GroupRepository;
using SIS.Domain.Entities;
using System.Data;

namespace SIS.MVC.Areas.Manage.Controllers
{
	[Area(nameof(Manage))]
	[Authorize(Roles = "SuperAdmin,Admin")]
	public class StudentController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IMediator _mediator;
		private readonly IDepartmentReadRepository _departmentReadRepository;
		private readonly IGroupReadRepository _groupReadRepository;

		public StudentController(UserManager<AppUser> userManager, IMediator mediator, 
			IDepartmentReadRepository departmentReadRepository,
			IGroupReadRepository groupReadRepository)
		{
			_userManager = userManager;
			_mediator = mediator;
			_departmentReadRepository = departmentReadRepository;
			_groupReadRepository = groupReadRepository;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Create()
		{
			ViewData["Departments"] = _departmentReadRepository.GetAll().ToList();
			ViewData["Groups"] = _groupReadRepository.GetAll().ToList();

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateStudentCommandRequest request)
		{
			ViewData["Departments"] = _departmentReadRepository.GetAll().ToList();
			ViewData["Groups"] = _groupReadRepository.GetAll().ToList();

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
