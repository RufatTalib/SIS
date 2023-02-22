﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.Features.Commands.GroupCommand.CreateGroup;
using SIS.Application.Features.Commands.GroupCommand.DeleteGroup;
using SIS.Application.Features.Queries.GroupQuery.GetAll;
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

		public async Task<IActionResult> Index(GetAllGroupQueryRequest request)
		{
			return View(await _mediator.Send(request));
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateGroupCommandRequest request)
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