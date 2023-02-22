using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Repositories.SliderImageRepository;
using SIS.Application.Repositories.SliderRepository;

namespace SIS.MVC.ViewComponents
{
	public class SliderVC : ViewComponent
	{
		private readonly ISliderReadRepository _sliderReadRepository;

		public SliderVC(ISliderReadRepository sliderReadRepository)
		{
			_sliderReadRepository = sliderReadRepository;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View(
				_sliderReadRepository.GetWhere(x => x.IsDeleted == false)
				.Include(x => x.Images)
				.ToList()
				);
		}
	}
}
