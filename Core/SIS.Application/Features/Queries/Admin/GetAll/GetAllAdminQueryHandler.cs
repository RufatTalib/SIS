using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.Admin.GetAll
{
	public class GetAllAdminQueryHandler : IRequestHandler<GetAllAdminQueryRequest, GetAllAdminQueryResponse>
	{
		private readonly UserManager<AppUser> _userManager;

		public GetAllAdminQueryHandler(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task<GetAllAdminQueryResponse> Handle(GetAllAdminQueryRequest request, CancellationToken cancellationToken)
		{
			IQueryable<AppUser> query = _userManager.Users.AsQueryable().Where(x => x.IdentityRoleName == "Administrator" && (x.IsDeleted == false || x.IsDeleted == null) );

			if (request.Page == 0) request.Page = 1;
			if (request.PageSize == 0) request.PageSize = 10;

			PaginatedList<AppUser> admins = PaginatedList<AppUser>.Create(query, request.Page, request.PageSize);

			return new GetAllAdminQueryResponse { Admins = admins};
		}
	}
}
