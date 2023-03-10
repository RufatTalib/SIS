using MediatR;
using Microsoft.AspNetCore.Identity;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.StudentQuery.GetById
{
	public class GetByIdStudentQueryHandler : IRequestHandler<GetByIdStudentQueryRequest, GetByIdStudentQueryResponse>
	{
		private readonly UserManager<AppUser> _userManager;

		public GetByIdStudentQueryHandler(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task<GetByIdStudentQueryResponse> Handle(GetByIdStudentQueryRequest request, CancellationToken cancellationToken)
		{
			return new() { Student = await _userManager.FindByIdAsync(request.Id) };
		}
	}
}
