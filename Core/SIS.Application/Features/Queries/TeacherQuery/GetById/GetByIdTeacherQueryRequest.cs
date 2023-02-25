using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.TeacherQuery.GetById
{
	public class GetByIdTeacherQueryRequest : IRequest<GetByIdTeacherQueryResponse>
	{
		public string Id { get; set; }
	}
}
