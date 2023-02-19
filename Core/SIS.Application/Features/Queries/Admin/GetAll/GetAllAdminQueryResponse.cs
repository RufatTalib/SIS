
using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;

namespace SIS.Application.Features.Queries.Admin.GetAll
{
	public class GetAllAdminQueryResponse
	{
		public PaginatedList<AppUser> Admins { get; set; }
	}
}
