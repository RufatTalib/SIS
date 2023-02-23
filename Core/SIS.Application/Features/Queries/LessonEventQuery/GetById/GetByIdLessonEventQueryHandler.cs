using MediatR;
using SIS.Application.Repositories.LessonEventRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.LessonEventQuery.GetById
{
	public class GetByIdLessonEventQueryHandler : IRequestHandler<GetByIdLessonEventQueryRequest, GetByIdLessonEventQueryResponse>
	{
		private readonly ILessonEventReadRepository _lessonEventReadRepository;

		public GetByIdLessonEventQueryHandler(ILessonEventReadRepository lessonEventReadRepository)
		{
			_lessonEventReadRepository = lessonEventReadRepository;
		}
		public async Task<GetByIdLessonEventQueryResponse> Handle(GetByIdLessonEventQueryRequest request, CancellationToken cancellationToken)
		{
			return new() { LessonEvent = await _lessonEventReadRepository.GetByIdAsync(request.Id) };
		}
	}
}
