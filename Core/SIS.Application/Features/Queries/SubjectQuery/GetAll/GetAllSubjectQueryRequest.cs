using MediatR;
using SIS.Application.Features.Queries.Common;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.SubjectQuery.GetAll
{
	public class GetAllSubjectQueryRequest : IRequest<GetAllSubjectQueryResponse>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}
