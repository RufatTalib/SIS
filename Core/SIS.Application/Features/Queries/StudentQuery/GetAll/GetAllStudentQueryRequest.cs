using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.StudentQuery.GetAll
{
	public class GetAllStudentQueryRequest : IRequest<GetAllStudentQueryResponse>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}
