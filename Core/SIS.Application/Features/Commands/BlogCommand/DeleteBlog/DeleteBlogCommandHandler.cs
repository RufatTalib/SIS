using MediatR;
using SIS.Application.Repositories.BlogRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.BlogCommand.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommandRequest, DeleteBlogCommandResponse>
    {
        private readonly IBlogReadRepository _blogReadRepository;
        private readonly IBlogWriteRepository _blogWriteRepository;

        public DeleteBlogCommandHandler(IBlogReadRepository blogReadRepository, IBlogWriteRepository blogWriteRepository)
        {
            _blogReadRepository = blogReadRepository;
            _blogWriteRepository = blogWriteRepository;
        }
        public async Task<DeleteBlogCommandResponse> Handle(DeleteBlogCommandRequest request, CancellationToken cancellationToken)
        {
            Blog blog = await _blogReadRepository.GetByIdAsync(request.Id);

            if (blog is null)
                return new DeleteBlogCommandResponse { Success = false, ErrorMessage = "Blog not found !" };

            blog.IsDeleted = true;

            if (_blogWriteRepository.Update(blog))
                _blogWriteRepository.Save();
            else
                return new DeleteBlogCommandResponse() { Success = false, ErrorMessage = "Update operation failed !" };

            return new DeleteBlogCommandResponse { Success = true };
        }
    }
}
