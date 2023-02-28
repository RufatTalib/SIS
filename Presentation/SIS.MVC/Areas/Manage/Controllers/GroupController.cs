using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.Features.Commands.GroupCommand.CreateGroup;
using SIS.Application.Features.Commands.GroupCommand.DeleteGroup;
using SIS.Application.Features.Commands.GroupCommand.UpdateGroup;
using SIS.Application.Features.Commands.SubjectCommand.UpdateSubject;
using SIS.Application.Features.Queries.GroupQuery.GetAll;
using SIS.Application.Features.Queries.GroupQuery.GetById;
using SIS.Application.Features.Queries.GroupQuery.GetByIdDetail;
using System.Data;

namespace SIS.MVC.Areas.Manage.Controllers
{
	[Area(nameof(Manage))]
	[Authorize(Roles = "SuperAdmin,Admin")]
	public class GroupController : Controller
	{
		private readonly IMediator _mediator;

		public GroupController(IMediator mediator)
		{
			_mediator = mediator;
		}
		public void ViewDataConfig(string title, string nav1, string nav2)
		{
			ViewData["title"] = title;
			ViewData["nav1"] = nav1;
			ViewData["nav2"] = nav2;
		}

		public async Task<IActionResult> Index(GetAllGroupQueryRequest request)
		{
			ViewDataConfig("Group","Group","Index");
			ViewData["SearchByNameValue"] = request.SearchByName;

			return View(await _mediator.Send(request));
		}

		public async Task<IActionResult> Detail(GetByIdDetailGroupQueryRequest request)
		{
			ViewDataConfig("Detail Group", "Group", "Detail");

			var response = await _mediator.Send(request);

			if (response.Group is null) return NotFound();

			return View(response.Group);
		}

		public IActionResult Create()
		{
			ViewDataConfig("Add New", "Group", "Create");

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateGroupCommandRequest request)
		{
			ViewDataConfig("Add New", "Group", "Create");
			if (!ModelState.IsValid) return View(request);

			var response = await _mediator.Send(request);

			if (!response.Success)
			{
				ModelState.AddModelError("", response.ErrorMessage);

				return View(request);
			}

			return RedirectToAction("index");
		}

		public async Task<IActionResult> Update(GetByIdGroupQueryRequest request)
		{
			ViewDataConfig("Edit Group", "Group", "Update");

			var response = await _mediator.Send(request);

			if (response.Group is null) return NotFound();

			return View(new UpdateGroupCommandRequest() { Id = response.Group.Id, Name = response.Group.Name });
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateGroupCommandRequest request)
		{
			ViewDataConfig("Edit Group", "Group", "Update");
			if (!ModelState.IsValid) return View(request);

			var response = await _mediator.Send(request);

			if (!response.Success)
			{
				ModelState.AddModelError("", response.ErrorMessage);

				return View(request);
			}

			return RedirectToAction("index");
		}



		public async Task<IActionResult> Delete(DeleteGroupCommandRequest request)
		{
			var response = await _mediator.Send(request);

			if (response.Success)
				return Ok();
			else
				return NotFound();
		}

	}
}
