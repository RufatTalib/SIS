using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.Features.Commands.EventCommand.CreateEvent;
using SIS.Application.Features.Commands.EventCommand.DeleteEvent;
using SIS.Application.Features.Queries.EventQuery.GetAll;
using System.Data;

namespace SIS.MVC.Areas.Manage.Controllers
{
    [Area(nameof(Manage))]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class EventController : Controller
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }
		public void ViewDataConfig(string title, string nav1, string nav2)
		{
			ViewData["title"] = title;
			ViewData["nav1"] = nav1;
			ViewData["nav2"] = nav2;
		}

		public async Task<IActionResult> Index(GetAllEventQueryRequest request)
        {
            ViewDataConfig("Event","Event","Index");

            return View(await _mediator.Send(request));
        }

        public IActionResult Create()
        {
			ViewDataConfig("Add New", "Event", "Create");

			return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventCommandRequest request)
        {
			ViewDataConfig("Add New", "Event", "Create");
			if (!ModelState.IsValid) return View(request);

            var response = await _mediator.Send(request);

            if (!response.Success)
            {
                ModelState.AddModelError("", response.ErrorMessage);

                return View(request);
            }

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(DeleteEventCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.Success)
                return Ok();
            else
                return NotFound();
        }

    }
}
