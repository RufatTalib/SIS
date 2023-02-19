using MediatR;
using SIS.Application.Features.Queries.Admin.GetAll;
using SIS.Application.Repositories.DepartmentRepository;
using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.DepartmentQuery.GetAll
{
	public class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQueryRequest, GetAllDepartmentQueryResponse>
	{
		private readonly IDepartmentReadRepository _departmentReadRepository;

		public GetAllDepartmentQueryHandler(IDepartmentReadRepository departmentReadRepository)
		{
			_departmentReadRepository = departmentReadRepository;
		}
		public async Task<GetAllDepartmentQueryResponse> Handle(GetAllDepartmentQueryRequest request, CancellationToken cancellationToken)
		{
			IQueryable<Department> query = _departmentReadRepository.Table.AsQueryable().Where(x => x.IsDeleted == false);

			if (request.Page == 0) request.Page = 1;
			if (request.PageSize == 0) request.PageSize = 10;

			PaginatedList<Department> departments = PaginatedList<Department>.Create(query, request.Page, request.PageSize);

			return new GetAllDepartmentQueryResponse { Departments = departments };

		}
	}
}
