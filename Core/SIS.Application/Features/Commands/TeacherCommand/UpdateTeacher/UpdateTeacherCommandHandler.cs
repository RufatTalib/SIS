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

namespace SIS.Application.Features.Commands.TeacherCommand.UpdateTeacher
{
	public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommandRequest, UpdateTeacherCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ISubjectReadRepository _subjectReadRepository;

		public UpdateTeacherCommandHandler(UserManager<AppUser> userManager, ISubjectReadRepository subjectReadRepository)
		{
			_userManager = userManager;
			_subjectReadRepository = subjectReadRepository;
		}
		public async Task<UpdateTeacherCommandResponse> Handle(UpdateTeacherCommandRequest request, 
			CancellationToken cancellationToken)
		{
			AppUser? teacher = _userManager.Users.Include(x => x.Department)
				.Include(x => x.Subjects)
				.FirstOrDefault(x => x.IsDeleted == false && x.Id == request.Id);

			if(teacher == null) return new() { Success = false, ErrorMessage = "Teacher doesn't exist !" };

			// check username already take condition
			if( _userManager.Users.FirstOrDefault( 
				x => x.IsDeleted == false
				&& x.Id != request.Id
				&& x.UserName == request.UserName			
			) is not null)
				return new() { Success = false, ErrorMessage = "Username already exists" };

			// check email already take condition
			if (_userManager.Users.FirstOrDefault(
				x => x.IsDeleted == false
				&& x.Id != request.Id
				&& x.Email == request.Email
			) is not null)
				return new() { Success = false, ErrorMessage = "Email already exists" };


			teacher.FirstName = request.FirstName;
			teacher.LastName = request.LastName;
			teacher.UserName = request.UserName;
			teacher.Email = request.Email;
			teacher.Adress = request.Adress;
			teacher.BirthDate = request.BirthDate;
			teacher.Qualification = request.Qualification;
			teacher.DepartmentId = request.DepartmentId;
			teacher.ClassNumber = request.ClassNumber;

			List<Subject> subjects = new();

			foreach(int id in request.SubjectIds)
			{
				subjects.Add(await _subjectReadRepository.FirstOrDefaultAsync(x => x.Id == id));
			}

			teacher.Subjects.AddRange(subjects);

			var result = await _userManager.UpdateAsync(teacher);
			if (!result.Succeeded)
				return new() { Success = false, ErrorMessage = result.Errors.FirstOrDefault().Description };

			return new() { Success = true };

		}
	}
}
