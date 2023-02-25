using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Repositories.EventRepository;
using SIS.Application.Repositories.SliderImageRepository;
using SIS.Application.Repositories.SliderRepository;

namespace SIS.MVC.ViewComponents
{
	public class EventVC : ViewComponent
	{
		private readonly IEventReadRepository _repository;

		public EventVC(IEventReadRepository repository)
		{
			_repository = repository;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var result = _repository.GetWhere(x => x.IsDeleted == false)
				.ToList();

			result.Sort((x, y) => DateTime.Compare(x.StartedDate, y.StartedDate));

			return View(
				result
				);
		}
	}
}
