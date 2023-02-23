using MediatR;
using Microsoft.AspNetCore.Identity;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.TeacherCommand.UpdateTeacher
{
	public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommandRequest, UpdateTeacherCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;

		public UpdateTeacherCommandHandler(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task<UpdateTeacherCommandResponse> Handle(UpdateTeacherCommandRequest request, 
			CancellationToken cancellationToken)
		{
			AppUser? teacher = _userManager.Users.FirstOrDefault(x => x.IsDeleted == false && x.Id == request.Id);

			if(teacher == null) return new() { Success = false, ErrorMessage = "Teacher doesn't exist !" };

			teacher.FirstName = request.FirstName;
			teacher.LastName = request.LastName;
			


			return new() { Success = true };
		}
	}
}
