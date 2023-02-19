using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.Features.Commands.SubjectCommand.CreateSubject;
using SIS.Application.Features.Commands.SubjectCommand.DeleteSubject;
using SIS.Application.Features.Commands.SubjectCommand.UpdateSubject;
using SIS.Application.Features.Queries.SubjectQuery.GetAll;
using SIS.Application.Features.Queries.SubjectQuery.GetById;
using SIS.Application.Repositories.SubjectRepository;
using SIS.Domain.Entities;
using System.Data;

namespace SIS.MVC.Areas.Manage.Controllers
{
	[Area(nameof(Manage))]
	[Authorize(Roles = "SuperAdmin,Admin")]
	public class SubjectController : Controller
	{
		private readonly IMediator _mediator;
		private readonly ISubjectReadRepository _subjectReadRepository;
		private readonly ISubjectWriteRepository _subjectWriteRepository;

		public SubjectController(IMediator mediator, ISubjectReadRepository subjectReadRepository, ISubjectWriteRepository subjectWriteRepository)
		{
			_mediator = mediator;
			_subjectReadRepository = subjectReadRepository;
			_subjectWriteRepository = subjectWriteRepository;
		}
		public async Task<IActionResult> Index(GetAllSubjectQueryRequest request)
		{
			return View(await _mediator.Send(request));
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateSubjectCommandRequest request)
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

		public async Task<IActionResult> Update(GetByIdSubjectQueryRequest request)
		{
			var response = await _mediator.Send(request);

			if (response.Subject is null) return NotFound();

			return View(new UpdateSubjectCommandRequest() { Id = response.Subject.Id, Name = response.Subject.Name});
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateSubjectCommandRequest request)
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


		public async Task<IActionResult> Delete(DeleteSubjectCommandRequest request)
		{
			var response = await _mediator.Send(request);

			if (response.Success)
				return Ok();
			else
				return NotFound();
		}
	}
}
