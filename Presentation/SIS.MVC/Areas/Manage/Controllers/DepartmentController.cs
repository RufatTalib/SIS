using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.Features.Commands.Admin.UpdateAdmin;
using SIS.Application.Features.Commands.DepartmentCommand.CreateDepartment;
using SIS.Application.Features.Commands.DepartmentCommand.UpdateDepartment;
using SIS.Application.Features.Queries.DepartmentQuery.GetAll;
using SIS.Application.Repositories.DepartmentRepository;
using SIS.Domain.Entities;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SIS.MVC.Areas.Manage.Controllers
{
    [Area(nameof(Manage))]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class DepartmentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IDepartmentReadRepository _departmentReadRepository;
		private readonly IDepartmentWriteRepository _departmentWriteRepository;

		public DepartmentController(IMediator mediator, IDepartmentReadRepository departmentReadRepository, IDepartmentWriteRepository departmentWriteRepository)
        {
            _mediator = mediator;
            _departmentReadRepository = departmentReadRepository;
			_departmentWriteRepository = departmentWriteRepository;
		}
		public void ViewDataConfig(string title, string nav1, string nav2)
		{
			ViewData["title"] = title;
			ViewData["nav1"] = nav1;
			ViewData["nav2"] = nav2;
		}
		public async Task<IActionResult> Index(GetAllDepartmentQueryRequest request)
        {
            ViewDataConfig("Department","Department","Index");

			ViewData["SearchByNameValue"] = request.SearchByName;
			ViewData["SearchByStartedYearValue"] = request.SearchByStartedYear;
			ViewData["SearchByNumberOfStudentValue"] = request.SearchByNumberOfStudent;


			return View(await _mediator.Send(request));
		}

        public IActionResult Create()
        {
			ViewDataConfig("Add New", "Department", "Create");

			return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentCommandRequest request)
        {
			ViewDataConfig("Add New", "Department", "Create");
			if (!ModelState.IsValid) return View(request);

            var response = await _mediator.Send(request);

            if (!response.Success)
            {
                ModelState.AddModelError("", response.ErrorMessage);

                return View(request);
            }

            return RedirectToAction("index");
        }

        public IActionResult ErrorPage()
        {
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
			ViewDataConfig("Edit Department", "Department", "Update");
			Department department = await _departmentReadRepository.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            if (department is null)
                return View(nameof(ErrorPage));


            UpdateDepartmentCommandRequest request = new()
            {
                Name = department.Name,
                HeadOfDepartment = department.HeadOfDepartment,
                StartedDate= department.StartedDate
            };

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateDepartmentCommandRequest request)
        {
			ViewDataConfig("Edit Department", "Department", "Update");
			if (!ModelState.IsValid) return View(request);

            var response = await _mediator.Send(request);

            if (!response.Success)
            {
                ModelState.AddModelError("", response.ErrorMessage);

                return View(request);
            }

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(int id)
        {
			Department department = await _departmentReadRepository.GetByIdAsync(id);

			if (department is null) return View(nameof(ErrorPage));

			department.IsDeleted = true;

			if (!_departmentWriteRepository.Update(department))
				return View(nameof(ErrorPage));

			_departmentWriteRepository.Save();

			return Ok();
		}
    }
}
