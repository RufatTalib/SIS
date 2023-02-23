using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.LessonEventQuery.GetById
{
	public class GetByIdLessonEventQueryRequest : IRequest<GetByIdLessonEventQueryResponse>
	{
		public int Id { get; set; }
	}
}
