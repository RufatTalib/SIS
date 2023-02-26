using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Features.Commands.LessonEventCommand.CreateLessonEvent;
using SIS.Application.Features.Commands.LessonEventCommand.DeleteLessonEvent;
using SIS.Application.Features.Commands.LessonEventCommand.UpdateLessonEvent;
using SIS.Application.Features.Queries.LessonEventQuery.GetAll;
using SIS.Application.Features.Queries.LessonEventQuery.GetById;
using SIS.Application.Repositories.GroupRepository;
using SIS.Application.Repositories.SubjectRepository;
using SIS.Domain.Entities;
using System.Data;

namespace SIS.MVC.Areas.Manage.Controllers
{
	[Area(nameof(Manage))]
	[Authorize(Roles = "SuperAdmin,Admin")]
	public class LessonEventController : Controller
	{
		private readonly IMediator _mediator;
		private readonly IGroupReadRepository _groupReadRepository;
		private readonly ISubjectReadRepository _subjectReadRepository;
		private readonly UserManager<AppUser> _userManager;

		public LessonEventController(IMediator mediator, IGroupReadRepository groupReadRepository,
			ISubjectReadRepository subjectReadRepository,
			UserManager<AppUser> userManager)
		{
			_mediator = mediator;
			_groupReadRepository = groupReadRepository;
			_subjectReadRepository = subjectReadRepository;
			_userManager = userManager;
		}

		public void ViewDataConfig(string title, string nav1, string nav2)
		{
			ViewData["title"] = title;
			ViewData["nav1"] = nav1;
			ViewData["nav2"] = nav2;
		}

		public async Task<IActionResult> Index(GetAllLessonEventQueryRequest request)
		{
			ViewDataConfig("Lesson Event", "Lesson Event", "Index");

			return View(await _mediator.Send(request));
		}

		public IActionResult Create()
		{
			ViewDataConfig("Add New", "Lesson Event", "Create");

			ViewData["Groups"] = _groupReadRepository.GetWhere(x => x.IsDeleted == false).ToList();
			ViewData["Subjects"] = _subjectReadRepository.GetWhere(x => x.IsDeleted == false).ToList();

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateLessonEventCommandRequest request)
		{
			ViewDataConfig("Add New", "Lesson Event", "Create");
			ViewData["Groups"] = _groupReadRepository.GetWhere(x => x.IsDeleted == false).ToList();
			ViewData["Subjects"] = _subjectReadRepository.GetWhere(x => x.IsDeleted == false).ToList();

			if (!ModelState.IsValid) return View(request);

			var response = await _mediator.Send(request);

			if (!response.Success)
			{
				ModelState.AddModelError("", response.ErrorMessage);

				return View(request);
			}

			return RedirectToAction("index");
		}

		public async Task<IActionResult> Update(GetByIdLessonEventQueryRequest request)
		{
			ViewDataConfig("Edit Lesson Event", "Lesson Event", "Update");
			var response = await _mediator.Send(request);

			if (response.LessonEvent is null) return NotFound();

			ViewData["Groups"] = _groupReadRepository.GetWhere(x => x.IsDeleted == false).ToList();
			ViewData["Subjects"] = _subjectReadRepository.GetWhere(x => x.IsDeleted == false).ToList();
			ViewData["Teachers"] = _userManager.Users
				.Where(x => x.IsDeleted == false)
				.Include(x => x.Subjects)
				.Where(x => x.Subjects.Contains(response.LessonEvent.Subject) )
				.ToList();


			return View(new UpdateLessonEventCommandRequest()
			{
				Id = response.LessonEvent.Id,
				Name = response.LessonEvent.Name,
				EndDate = response.LessonEvent.EndDate,
				StartDate = response.LessonEvent.StartedDate,
				ClassNumber = response.LessonEvent.ClassNumber,
				GroupId = response.LessonEvent.GroupId,
				Period = response.LessonEvent.Period,
				SubjectId = response.LessonEvent.SubjectId
			});
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateLessonEventCommandRequest request)
		{
			ViewDataConfig("Edit Lesson Event", "Lesson Event", "Update");
			if (!ModelState.IsValid) return View(request);

			var response = await _mediator.Send(request);

			if (!response.Success)
			{
				ViewData["Groups"] = _groupReadRepository.GetWhere(x => x.IsDeleted == false).ToList();
				ViewData["Subjects"] = _subjectReadRepository.GetWhere(x => x.IsDeleted == false).ToList();
				ViewData["Teachers"] = _userManager.Users
					.Where(x => x.IsDeleted == false)
					.Include(x => x.Subjects)
					.Where(x => x.Subjects.Any(subj => subj.Id == request.SubjectId))
					.ToList();

				ModelState.AddModelError("", response.ErrorMessage);

				return View(request);
			}

			return RedirectToAction("index");
		}

		public async Task<IActionResult> Delete(DeleteLessonEventCommandRequest request)
		{
			var response = await _mediator.Send(request);

			if (response.Success)
				return Ok();
			else
				return NotFound();
		}

	}
}