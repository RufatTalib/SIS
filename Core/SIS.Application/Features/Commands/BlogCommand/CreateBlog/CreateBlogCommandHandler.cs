using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SIS.Application.Extentions;
using SIS.Application.Repositories.BlogRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.BlogCommand.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommandRequest, CreateBlogCommandResponse>
    {
        private readonly IBlogWriteRepository _blogWriteRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _env;

        public CreateBlogCommandHandler(IBlogWriteRepository blogWriteRepository, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env)
        {
            _blogWriteRepository = blogWriteRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _env = env;
        }
        public async Task<CreateBlogCommandResponse> Handle(CreateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            // Manage autherized so we don't need to check is user authenticated or not
            string username = _httpContextAccessor.HttpContext.User.Identity.Name;

            AppUser user = await _userManager.FindByNameAsync(username);

            Blog blog = new Blog()
            {
                Active = true,
                CreatedDate = DateTime.Now,
                Description = request.Description,
                IsDeleted = false,
                RemovedDate = null,
                Owner = user,
                OwnerId = user.Id,
                Title = request.Title,
                ViewCount = 0,
                ImageUrl = request.Image.Save(_env.WebRootPath, "BlogPhotos")
            };

            if (_blogWriteRepository.Add(blog))
                _blogWriteRepository.Save();
            else
                return new() { Success = false, ErrorMessage = "Can't create blog!" };

            return new() { Success = true };
        }
    }
}
