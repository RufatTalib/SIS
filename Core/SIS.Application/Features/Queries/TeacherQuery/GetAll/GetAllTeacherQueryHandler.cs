using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Features.Queries.Admin.GetAll;
using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.TeacherQuery.GetAll
{
	public class GetAllTeacherQueryHandler : IRequestHandler<GetAllTeacherQueryRequest, GetAllTeacherQueryResponse>
	{
		private readonly UserManager<AppUser> _userManager;

		public GetAllTeacherQueryHandler(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task<GetAllTeacherQueryResponse> Handle(GetAllTeacherQueryRequest request, CancellationToken cancellationToken)
		{
			IQueryable<AppUser> query = _userManager.Users.AsQueryable().Where(x => x.IdentityRoleName == "Teacher" && (x.IsDeleted == false || x.IsDeleted == null))
				.Include(x => x.Department);

			if (request.Page == 0) request.Page = 1;
			if (request.PageSize == 0) request.PageSize = 10;
			if (request.SearchByName != null) query = query.Where(x => x.FirstName.Contains(request.SearchByName));
			if (request.SearchBySurname != null) query = query.Where(x => x.LastName.Contains(request.SearchBySurname));
			if (request.SearchByQualification != null) query = query.Where(x => x.Qualification.Contains(request.SearchByQualification));
			if (request.SearchBySubject != null)
				query = query.Where(x => x.Subjects.Any(subject => subject.Name.Contains(request.SearchBySubject) ) );

			PaginatedList<AppUser> teachers = PaginatedList<AppUser>.Create(query, request.Page, request.PageSize);

			return new GetAllTeacherQueryResponse { Teachers = teachers };
		}
	}
}
