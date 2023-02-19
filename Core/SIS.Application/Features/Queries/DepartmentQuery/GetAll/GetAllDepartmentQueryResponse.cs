using SIS.Infrastructure.Tools;
using SIS.Domain.Entities;

namespace SIS.Application.Features.Queries.DepartmentQuery.GetAll
{
	public class GetAllDepartmentQueryResponse
	{
		public PaginatedList<Department> Departments { get; set; }
	}
}
