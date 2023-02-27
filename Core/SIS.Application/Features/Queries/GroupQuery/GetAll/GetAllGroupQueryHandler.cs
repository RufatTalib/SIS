using MediatR;
using SIS.Application.Repositories.GroupRepository;
using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;

namespace SIS.Application.Features.Queries.GroupQuery.GetAll
{
	public class GetAllGroupQueryHandler : IRequestHandler<GetAllGroupQueryRequest, GetAllGroupQueryResponse>
	{
		private readonly IGroupReadRepository _groupReadRepository;

		public GetAllGroupQueryHandler(IGroupReadRepository groupReadRepository)
		{
			_groupReadRepository = groupReadRepository;
		}

		public async Task<GetAllGroupQueryResponse> Handle(GetAllGroupQueryRequest request, CancellationToken cancellationToken)
		{
			IQueryable<Group> query = _groupReadRepository.Table.AsQueryable().Where(x => x.IsDeleted == false);

			if (request.Page == 0) request.Page = 1;
			if (request.PageSize == 0) request.PageSize = 10;
			if (request.SearchByName != null)
				query = query.Where(x => x.Name.Contains(request.SearchByName));

			PaginatedList<Group> groups = PaginatedList<Group>.Create(query, request.Page, request.PageSize);

			return new GetAllGroupQueryResponse { Groups = groups };
		}
	}
}
