using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.Features.Commands.SettingCommand.UpdateSetting;
using SIS.Application.Features.Queries.SettingQuery.GetAll;
using System.Data;

namespace SIS.MVC.Areas.Manage.Controllers
{
	[Area(nameof(Manage))]
	[Authorize(Roles = "SuperAdmin")]
	public class SettingController : Controller
	{
		private readonly IMediator _mediator;

		public SettingController(IMediator mediator)
		{
			_mediator = mediator;
		}

		public void ViewDataConfig(string title, string nav1, string nav2)
		{
			ViewData["title"] = title;
			ViewData["nav1"] = nav1;
			ViewData["nav2"] = nav2;
		}


		public async Task<IActionResult> Index(GetAllSettingQueryRequest request)
		{
			ViewDataConfig("Setting","Setting","Index");

			return View((await _mediator.Send(request)).Request);
		}

		[HttpPost]
		public async Task<IActionResult> Index(UpdateSettingCommandRequest request)
		{
			ViewDataConfig("Setting", "Setting", "Index");

			if (!ModelState.IsValid) return View(request);

			var response = await _mediator.Send(request);

			if (!response.Success)
			{
				ModelState.AddModelError("", response.ErrorMessage);

				return View(request);
			}

			return RedirectToAction("Index");
		}


	}
}
