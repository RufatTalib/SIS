using MediatR;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Features.Queries.EventQuery.GetAll;
using SIS.Application.Repositories.EventRepository;
using SIS.Application.Repositories.LessonEventRepository;
using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.LessonEventQuery.GetAll
{
    public class GetAllLessonEventQueryHandler : IRequestHandler<GetAllLessonEventQueryRequest, GetAllLessonEventQueryResponse>
    {
        private readonly ILessonEventReadRepository _lessonEventReadRepository;

        public GetAllLessonEventQueryHandler(ILessonEventReadRepository lessonEventReadRepository)
        {
            _lessonEventReadRepository = lessonEventReadRepository;
        }
        public async Task<GetAllLessonEventQueryResponse> Handle(GetAllLessonEventQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<LessonEvent> query = _lessonEventReadRepository.Table.AsQueryable()
                .Where(x => x.IsDeleted == false)
                .Include(x => x.Subject)
                .Include(x => x.Group)
                .Include(x => x.Teacher);

            if (request.Page == 0) request.Page = 1;
            if (request.PageSize == 0) request.PageSize = 10;
            if (request.SearchByTeacherName != null)
                query = query.Where(x => x.Teacher.FirstName.Contains(request.SearchByTeacherName));
            if (request.SearchByTeacherSurname != null)
                query = query.Where(x => x.Teacher.LastName.Contains(request.SearchByTeacherSurname));
            if (request.SearchByGroup != null)
                query = query.Where(x => x.Group.Name.Contains(request.SearchByGroup));
            if (request.SearchByRoomNumber != null)
                query = query.Where(x => x.ClassNumber.ToString().Contains(request.SearchByRoomNumber));

            PaginatedList<LessonEvent> lessonEvents = PaginatedList<LessonEvent>.Create(query, request.Page, request.PageSize);

            return new GetAllLessonEventQueryResponse { LessonEvents = lessonEvents };
        }
    }
}
