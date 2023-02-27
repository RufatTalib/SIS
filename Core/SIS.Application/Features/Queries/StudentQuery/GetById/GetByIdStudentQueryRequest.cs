using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.StudentQuery.GetById
{
	public class GetByIdStudentQueryRequest : IRequest<GetByIdStudentQueryResponse>
	{
		public string Id { get; set; }
	}
}
