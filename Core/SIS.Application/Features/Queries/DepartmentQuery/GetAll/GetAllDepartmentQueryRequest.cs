using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.DepartmentQuery.GetAll
{
	public class GetAllDepartmentQueryRequest : IRequest<GetAllDepartmentQueryResponse>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
		public string? SearchByName { get; set; }
        public string? SearchByStartedYear { get; set; }
        public string? SearchByNumberOfStudent { get; set; }

    }
}
