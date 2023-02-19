using MediatR;
using SIS.Application.Repositories.DepartmentRepository;
using SIS.Application.Repositories.SubjectRepository;
using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.SubjectQuery.GetAll
{
	public class GetAllSubjectQueryHandler : IRequestHandler<GetAllSubjectQueryRequest, GetAllSubjectQueryResponse>
	{
		private readonly ISubjectReadRepository _subjectReadRepository;

		public GetAllSubjectQueryHandler(ISubjectReadRepository subjectReadRepository)
		{;
			_subjectReadRepository = subjectReadRepository;
		}
		public async Task<GetAllSubjectQueryResponse> Handle(GetAllSubjectQueryRequest request, CancellationToken cancellationToken)
		{
			IQueryable<Subject> query = _subjectReadRepository.Table.AsQueryable().Where(x => x.IsDeleted == false);

			if (request.Page == 0) request.Page = 1;
			if (request.PageSize == 0) request.PageSize = 10;

			PaginatedList<Subject> subjects = PaginatedList<Subject>.Create(query, request.Page, request.PageSize);

			return new GetAllSubjectQueryResponse() { Subjects = subjects };
		}
	}
}
