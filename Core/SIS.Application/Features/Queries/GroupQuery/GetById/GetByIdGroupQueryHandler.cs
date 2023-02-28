using MediatR;
using SIS.Application.Repositories.GroupRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.GroupQuery.GetById
{
	public class GetByIdGroupQueryHandler : IRequestHandler<GetByIdGroupQueryRequest, GetByIdGroupQueryResponse>
	{
		private readonly IGroupReadRepository _groupReadRepository;

		public GetByIdGroupQueryHandler(IGroupReadRepository groupReadRepository)
		{
			_groupReadRepository = groupReadRepository;
		}
		public async Task<GetByIdGroupQueryResponse> Handle(GetByIdGroupQueryRequest request, CancellationToken cancellationToken)
		{
			return new()
			{
				Group = await _groupReadRepository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == request.Id)
			};
		}
	}
}
