using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.GroupQuery.GetByIdDetail
{
	public class GetByIdDetailGroupQueryRequest : IRequest<GetByIdDetailGroupQueryResponse>
	{
		public int Id { get; set; }
	}
}
