using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.Features.Commands.TeacherCommand.CreateTeacher;
using SIS.Application.Features.Commands.TeacherCommand.UpdateTeacher;
using SIS.Application.Features.Queries.TeacherQuery.GetAll;
using SIS.Application.Features.Queries.TeacherQuery.GetById;
using SIS.Application.Repositories.DepartmentRepository;
using SIS.Application.Repositories.SubjectRepository;
using SIS.Domain.Entities;
using System.Data;
using System.Text.Json;

namespace SIS.MVC.Areas.Manage.Controllers
{
	[Area(nameof(Manage))]
	[Authorize(Roles = "SuperAdmin,Admin")]
	public class TeacherController : Controller
	{
		private readonly IMediator _mediator;
		private readonly UserManager<AppUser> _userManager;
		private readonly IDepartmentReadRepository _departmentReadRepository;
		private readonly ISubjectReadRepository _subjectReadRepository;
		private static List<int> _subjectIds = new List<int>();

		public TeacherController(IMediator mediator, UserManager<AppUser> userManager,
			IDepartmentReadRepository departmentReadRepository,
			ISubjectReadRepository subjectReadRepository)
		{
			_mediator = mediator;
			_userManager = userManager;
			_departmentReadRepository = departmentReadRepository;
			_subjectReadRepository = subjectReadRepository;


		}

		public void ViewDataConfig(string title, string nav1, string nav2)
		{
			ViewData["title"] = title;
			ViewData["nav1"] = nav1;
			ViewData["nav2"] = nav2;
		}

		public async Task<IActionResult> Index(GetAllTeacherQueryRequest request)
		{
			ViewDataConfig("Teacher", "Teacher", "Index");
			ViewData["SearchByNameValue"] = request.SearchByName;
			ViewData["SearchBySurnameValue"] = request.SearchBySurname;
			ViewData["SearchByQualificationValue"] = request.SearchByQualification;
			ViewData["SearchBySubjectValue"] = request.SearchBySubject;


			return View(await _mediator.Send(request));
		}

		public IActionResult Create()
		{
			ViewDataConfig("Add New", "Teacher", "Create");

			ViewData["Departments"] = _departmentReadRepository.GetAll().ToList();

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateTeacherCommandRequest request)
		{
			ViewDataConfig("Add New", "Teacher", "Create");

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

		public IActionResult GetAviableSubjects()
		{
			List<SubjectIdNameJsonClass> array = new List<SubjectIdNameJsonClass>();
			_subjectReadRepository.GetAll().ToList().ForEach(x =>
			{
				array.Add(new() { Id = x.Id, Name = x.Name });
			});
			return Json(array);
		}

		public async Task<IActionResult> Update(GetByIdTeacherQueryRequest request)
		{

			int count = _subjectReadRepository.GetAll().Count();
			List<int> subjectList = new List<int>(new int[count]);
			for (int i = 0; i < count; i++)
				subjectList[i] = -1;

			ViewDataConfig("Edit Teacher", "Teacher", "Edit");

			ViewData["Departments"] = _departmentReadRepository.GetAll().ToList();
			ViewData["Subjects"] = _subjectReadRepository.GetAll().ToList();


			var response = await _mediator.Send(request);

			if (response.Teacher is null) return NotFound();

			UpdateTeacherCommandRequest teacher = new UpdateTeacherCommandRequest()
			{
				Adress = response.Teacher.Adress,
				DepartmentId = response.Teacher.DepartmentId,
				FirstName = response.Teacher.FirstName,
				LastName = response.Teacher.LastName,
				UserName = response.Teacher.UserName,
				BirthDate = response.Teacher.BirthDate,
				ClassNumber = response.Teacher.ClassNumber,
				Email = response.Teacher.Email,
				Experience = response.Teacher.Experience,
				Gender = response.Teacher.Gender,
				Phone = response.Teacher.PhoneNumber,
				Qualification = response.Teacher.Qualification,
				SubjectIds = subjectList
			};


			return View(teacher);
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateTeacherCommandRequest request)
		{
			ViewDataConfig("Edit Teacher", "Teacher", "Edit");

			ViewData["Departments"] = _departmentReadRepository.GetAll().ToList();
			ViewData["Subjects"] = _subjectReadRepository.GetAll().ToList();

			if (!ModelState.IsValid) return View(request);

			var response = await _mediator.Send(request);

			if (!response.Success)
			{
				ModelState.AddModelError("", response.ErrorMessage);

				return View(request);
			}

			return RedirectToAction("index");
		}

		/*public async Task<IActionResult> Delete(DeleteTeacherCommandRequest request)
		{
			var response = await _mediator.Send(request);

			if (response.Success)
				return Ok();
			else
				return NotFound();
		}*/
	}
}
