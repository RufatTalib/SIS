using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.LessonEventQuery.GetAll
{
    public class GetAllLessonEventQueryRequest : IRequest<GetAllLessonEventQueryResponse>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchByTeacherName { get; set; }
        public string? SearchByTeacherSurname { get; set; }
        public string? SearchByGroup { get; set; }
        public string? SearchByRoomNumber { get; set; }
    }
}
