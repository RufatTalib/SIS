using MediatR;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.Features.Queries.SettingQuery.GetForHome;

namespace SIS.MVC.Controllers
{
    public class HomeController : Controller
    {
		private readonly IMediator _mediator;

		public HomeController(IMediator mediator)
        {
			_mediator = mediator;
		}
        public async Task<IActionResult> Index(GetForHomeSettingQueryRequest request)
        {
            return View(await _mediator.Send(request));
        }
    }
}
