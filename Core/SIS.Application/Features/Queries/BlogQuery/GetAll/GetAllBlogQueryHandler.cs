using MediatR;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Features.Queries.SubjectQuery.GetAll;
using SIS.Application.Repositories.BlogRepository;
using SIS.Application.Repositories.SubjectRepository;
using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;

namespace SIS.Application.Features.Queries.BlogQuery.GetAll
{
    public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQueryRequest, GetAllBlogQueryResponse>
    {
        private readonly IBlogReadRepository _blogReadRepository;

        public GetAllBlogQueryHandler(IBlogReadRepository blogReadRepository)
        {
            _blogReadRepository = blogReadRepository;
        }
        public async Task<GetAllBlogQueryResponse> Handle(GetAllBlogQueryRequest request, CancellationToken cancellationToken)
        {
			IQueryable<Blog> query = _blogReadRepository.Table.AsQueryable().Where(x => x.IsDeleted == false);

			if (request.Page == 0) request.Page = 1;
			if (request.PageSize == 0) request.PageSize = 10;

			PaginatedList<Blog> blogs = PaginatedList<Blog>.Create(query, request.Page, request.PageSize);

			return new GetAllBlogQueryResponse { Blogs = blogs };
		}
    }
}
