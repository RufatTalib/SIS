using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Repositories.SubjectRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.TeacherCommand.DeleteTeacher
{
	public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommandRequest, DeleteTeacherCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;

		public DeleteTeacherCommandHandler(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task<DeleteTeacherCommandResponse> Handle(DeleteTeacherCommandRequest request, CancellationToken cancellationToken)
		{
			AppUser teacher = await _userManager.Users
				.Include(x => x.Subjects)
				.Include(x => x.LessonEvents)
				.FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == request.Id);

			if (teacher == null) return new() { Success = false, ErrorMessage = "Teacher not found!" };
			teacher.IsDeleted = true;
			teacher.Subjects.Clear();
			teacher.LessonEvents.ForEach(x => x.IsDeleted = true);

			if (!(await _userManager.UpdateAsync(teacher)).Succeeded) return new() { Success = false, ErrorMessage = "Update operation failed!" };

			return new() { Success = true };
		}
	}
}
