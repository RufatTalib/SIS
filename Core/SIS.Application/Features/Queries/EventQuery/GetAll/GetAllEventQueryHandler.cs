using MediatR;
using SIS.Application.Features.Queries.SubjectQuery.GetAll;
using SIS.Application.Repositories.EventRepository;
using SIS.Application.Repositories.SubjectRepository;
using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.EventQuery.GetAll
{
    public class GetAllEventQueryHandler : IRequestHandler<GetAllEventQueryRequest, GetAllEventQueryResponse>
    {
        private readonly IEventReadRepository _eventReadRepository;

        public GetAllEventQueryHandler(IEventReadRepository eventReadRepository)
        {
            _eventReadRepository = eventReadRepository;
        }
        public async Task<GetAllEventQueryResponse> Handle(GetAllEventQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Event> query = _eventReadRepository.Table.AsQueryable().Where(x => x.IsDeleted == false);

            if (request.Page == 0) request.Page = 1;
            if (request.PageSize == 0) request.PageSize = 10;

            PaginatedList<Event> events = PaginatedList<Event>.Create(query, request.Page, request.PageSize);

            return new GetAllEventQueryResponse { Events = events };
        }
    }
}
