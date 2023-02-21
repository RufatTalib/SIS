using MediatR;
using Microsoft.AspNetCore.Hosting;
using SIS.Application.Extentions;
using SIS.Application.Repositories.BlogRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.BlogCommand.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommandRequest, UpdateBlogCommandResponse>
    {
        private readonly IBlogReadRepository _blogReadRepository;
        private readonly IBlogWriteRepository _blogWriteRepository;
        private readonly IWebHostEnvironment _env;

        public UpdateBlogCommandHandler(IBlogReadRepository blogReadRepository, IBlogWriteRepository blogWriteRepository, IWebHostEnvironment env)
        {
            _blogReadRepository = blogReadRepository;
            _blogWriteRepository = blogWriteRepository;
            _env = env;
        }
        public async Task<UpdateBlogCommandResponse> Handle(UpdateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            Blog blog = await _blogReadRepository.GetByIdAsync(request.BlogId);

            blog.Description = request.Description;
            blog.Title = request.Title;

            if (request.Image is not null)
                blog.ImageUrl = request.Image.Save(_env.WebRootPath, "BlogPhotos");

            if (_blogWriteRepository.Update(blog))
                _blogWriteRepository.Save();
            else
                return new() { Success = false, ErrorMessage = "Update operation failed !" };

            return new() { Success = true };
        }
    }
}
