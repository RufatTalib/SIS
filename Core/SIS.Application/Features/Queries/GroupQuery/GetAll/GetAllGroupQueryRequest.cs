using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.GroupQuery.GetAll
{
	public class GetAllGroupQueryRequest : IRequest<GetAllGroupQueryResponse>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
		public string? SearchByName { get; set; }
	}
}
