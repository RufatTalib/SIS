using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.Features.Commands.SliderCommand.CreateSlider;
using SIS.Application.Features.Commands.SliderCommand.DeleteSlider;
using SIS.Application.Features.Queries.SliderQuery.GetAll;
using System.Data;

namespace SIS.MVC.Areas.Manage.Controllers
{
	[Area(nameof(Manage))]
	[Authorize(Roles = "SuperAdmin,Admin")]
	public class SliderController : Controller
	{
		private readonly IMediator _mediator;

		public SliderController(IMediator mediator)
		{
			_mediator = mediator;
		}
		public void ViewDataConfig(string title, string nav1, string nav2)
		{
			ViewData["title"] = title;
			ViewData["nav1"] = nav1;
			ViewData["nav2"] = nav2;
		}
		public async Task<IActionResult> Index(GetAllSliderQueryRequest request)
		{
			ViewDataConfig("Slider", "Slider", "Index");

			return View(await _mediator.Send(request));
		}


		public IActionResult Create()
		{
			ViewDataConfig("Add New", "Slider", "Create");

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateSliderCommandRequest request)
		{
			ViewDataConfig("Add New", "Slider", "Create");
			if (!ModelState.IsValid) return View(request);

            var response = await _mediator.Send(request);

            if (!response.Success)
            {
                ModelState.AddModelError("", response.ErrorMessage);

                return View(request);
            }

            return RedirectToAction("index");

        }

		public async Task<IActionResult> Delete(DeleteSliderCommandRequest request)
		{
			var response = await _mediator.Send(request);

			if (response.Success)
				return Ok();
			else
				return NotFound();
		}

	}
}
