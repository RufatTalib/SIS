using MediatR;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Repositories.GroupRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.GroupQuery.GetByIdDetail
{
	public class GetByIdDetailGroupQueryHandler : IRequestHandler<GetByIdDetailGroupQueryRequest, GetByIdDetailGroupQueryResponse>
	{
		private readonly IGroupReadRepository _groupReadRepository;

		public GetByIdDetailGroupQueryHandler(IGroupReadRepository groupReadRepository)
		{
			_groupReadRepository = groupReadRepository;
		}
		public async Task<GetByIdDetailGroupQueryResponse> Handle(GetByIdDetailGroupQueryRequest request, CancellationToken cancellationToken)
		{
			return new()
			{
				Group = await _groupReadRepository
				.GetWhere(x => x.IsDeleted == false)
				.Include(x => x.Users)
				.FirstOrDefaultAsync(x => x.Id == request.Id)
			};
		}
	}
}
