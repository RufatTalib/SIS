using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.Features.Commands.StudentCommand.CreateStudent;
using SIS.Application.Features.Commands.StudentCommand.DeleteStudent;
using SIS.Application.Features.Commands.StudentCommand.UpdateStudent;
using SIS.Application.Features.Queries.StudentQuery.GetAll;
using SIS.Application.Features.Queries.StudentQuery.GetById;
using SIS.Application.Features.Queries.StudentQuery.GetByIdUpdate;
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
		public void ViewDataConfig(string title, string nav1, string nav2)
		{
			ViewData["title"] = title;
			ViewData["nav1"] = nav1;
			ViewData["nav2"] = nav2;
		}
		public async Task<IActionResult> Index(GetAllStudentQueryRequest request)
		{
			ViewDataConfig("Student", "Student", "Index");
			ViewData["SearchByGroupValue"] = request.SearchByGroup;
			ViewData["SearchBySurnameValue"] = request.SearchBySurname;
			ViewData["SearchByNameValue"] = request.SearchByName;

			return View(await _mediator.Send(request));
		}

		public IActionResult Create()
		{
			ViewDataConfig("Add New", "Student", "Create");
			ViewData["Departments"] = _departmentReadRepository.GetWhere(x => x.IsDeleted == false).ToList();
			ViewData["Groups"] = _groupReadRepository.GetWhere(x => x.IsDeleted == false).ToList();

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateStudentCommandRequest request)
		{
			ViewDataConfig("Add New", "Student", "Create");
			ViewData["Departments"] = _departmentReadRepository.GetWhere(x => x.IsDeleted == false).ToList();
			ViewData["Groups"] = _groupReadRepository.GetWhere(x => x.IsDeleted == false).ToList();

			if (!ModelState.IsValid) return View(request);

			var response = await _mediator.Send(request);

			if (!response.Success)
			{
				ModelState.AddModelError("", response.ErrorMessage);

				return View(request);
			}

			return RedirectToAction("index");
		}

		public async Task<IActionResult> Update(GetByIdUpdateStudentQueryRequest request)
		{
			ViewDataConfig("Edit Student", "Student", "Edit");
			ViewData["Departments"] = _departmentReadRepository.GetWhere(x => x.IsDeleted == false).ToList();
			ViewData["Groups"] = _groupReadRepository.GetWhere(x => x.IsDeleted == false).ToList();


			var response = await _mediator.Send(request);

			if (response.Request is null)
				return NotFound();


			
			return View(response.Request);
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateStudentCommandRequest request)
		{
			ViewDataConfig("Edit Student", "Student", "Edit");
			ViewData["Departments"] = _departmentReadRepository.GetWhere(x => x.IsDeleted == false).ToList();
			ViewData["Groups"] = _groupReadRepository.GetWhere(x => x.IsDeleted == false).ToList();


			if (!ModelState.IsValid) return View(request);

			var response = await _mediator.Send(request);

			if (!response.Success)
			{
				ModelState.AddModelError("", response.ErrorMessage);

				return View(request);
			}

			return RedirectToAction("index");
		}

		public async Task<IActionResult> Delete(DeleteStudentCommandRequest request)
		{
			var result = await _mediator.Send(request);
			if (result.Success)
				return Ok();
			else
				return Content(result.ErrorMessage);
		}
	}
}
