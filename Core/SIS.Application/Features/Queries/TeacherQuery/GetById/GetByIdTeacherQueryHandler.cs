using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.TeacherQuery.GetById
{
	public class GetByIdTeacherQueryHandler : IRequestHandler<GetByIdTeacherQueryRequest, GetByIdTeacherQueryResponse>
	{
		private readonly UserManager<AppUser> _userManager;

		public GetByIdTeacherQueryHandler(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task<GetByIdTeacherQueryResponse> Handle(GetByIdTeacherQueryRequest request, CancellationToken cancellationToken)
		{
			return new() { Teacher = await _userManager.Users.Include(x => x.Subjects).FirstOrDefaultAsync(
				x => x.IsDeleted == false 
				&& x.Id == request.Id) };
		}
	}
}
