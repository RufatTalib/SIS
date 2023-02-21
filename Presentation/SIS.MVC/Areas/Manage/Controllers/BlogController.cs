using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.Features.Commands.BlogCommand.CreateBlog;
using SIS.Application.Features.Commands.BlogCommand.DeleteBlog;
using SIS.Application.Features.Commands.BlogCommand.UpdateBlog;
using SIS.Application.Features.Queries.BlogQuery.GetAll;
using SIS.Application.Features.Queries.BlogQuery.GetById;
using SIS.Application.Repositories.BlogRepository;

namespace SIS.MVC.Areas.Manage.Controllers
{
    [Area(nameof(Manage))]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class BlogController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IBlogReadRepository _blogReadRepository;
        private readonly IBlogWriteRepository _blogWriteRepository;

        public BlogController(IMediator mediator, IBlogReadRepository blogReadRepository, IBlogWriteRepository blogWriteRepository)
        {
            _mediator = mediator;
            _blogReadRepository = blogReadRepository;
            _blogWriteRepository = blogWriteRepository;
        }

        public async Task<IActionResult> Index(GetAllBlogQueryRequest request)
        {
            var response = await _mediator.Send(request);

			return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommandRequest request)
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

        public async Task<IActionResult> Update(GetByIdBlogQueryRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.Blog is null) return NotFound();

            return View(new UpdateBlogCommandRequest() 
            { 
                BlogId = response.Blog.Id, 
                Title = response.Blog.Title,
                Description = response.Blog.Description
            }
            );
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogCommandRequest request)
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


        public async Task<IActionResult> Delete(DeleteBlogCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.Success)
                return Ok();
            else
                return NotFound();
        }


    }
}
