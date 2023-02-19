using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.SubjectQuery.GetById
{
	public class GetByIdSubjectQueryRequest : IRequest<GetByIdSubjectQueryResponse>
	{
		public int Id { get; set; }
	}
}
