using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Repositories;
using SIS.Application.Repositories.BlogRepository;

namespace SIS.MVC.ViewComponents
{
	public class BlogVC : ViewComponent
	{
		private readonly IBlogReadRepository _blogReadRepository;

		public BlogVC(IBlogReadRepository blogReadRepository)
		{
			_blogReadRepository = blogReadRepository;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var result = _blogReadRepository.GetWhere(x => x.IsDeleted == false).Include(x => x.Owner).ToList();

			return View(result);
		}
	}
}
