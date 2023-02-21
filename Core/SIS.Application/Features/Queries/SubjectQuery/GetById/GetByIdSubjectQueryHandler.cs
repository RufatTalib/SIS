using MediatR;
using SIS.Application.Repositories.SubjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.SubjectQuery.GetById
{
	public class GetByIdSubjectQueryHandler : IRequestHandler<GetByIdSubjectQueryRequest, GetByIdSubjectQueryResponse>
	{
		private readonly ISubjectReadRepository _subjectReadRepository;

		public GetByIdSubjectQueryHandler(ISubjectReadRepository subjectReadRepository)
		{
			_subjectReadRepository = subjectReadRepository;
		}
		public async Task<GetByIdSubjectQueryResponse> Handle(GetByIdSubjectQueryRequest request, CancellationToken cancellationToken)
		{
			return new()
			{
				Subject = await _subjectReadRepository.GetByIdAsync(request.Id)
			};
		}
	}
}
