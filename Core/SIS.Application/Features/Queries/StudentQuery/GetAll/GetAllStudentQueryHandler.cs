using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;

namespace SIS.Application.Features.Queries.StudentQuery.GetAll
{
	public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQueryRequest, GetAllStudentQueryResponse>
	{
		private readonly UserManager<AppUser> _userManager;

		public GetAllStudentQueryHandler(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task<GetAllStudentQueryResponse> Handle(GetAllStudentQueryRequest request, CancellationToken cancellationToken)
		{
			IQueryable<AppUser> query = _userManager.Users.AsQueryable().Where(
				x => x.IdentityRoleName == "Student" && (x.IsDeleted == false || x.IsDeleted == null))
				.Include(x => x.Department).Include(x => x.Groups);

			if (request.Page == 0) request.Page = 1;
			if (request.PageSize == 0) request.PageSize = 10;

			PaginatedList<AppUser> students = PaginatedList<AppUser>.Create(query, request.Page, request.PageSize);

			return new GetAllStudentQueryResponse { Students = students };
		}
	}
}
