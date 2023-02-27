using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Extentions;
using SIS.Application.Repositories.GroupRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.StudentCommand.UpdateStudent
{
	public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommandRequest, UpdateStudentCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IGroupReadRepository _groupReadRepository;
		private readonly IWebHostEnvironment _env;

		public UpdateStudentCommandHandler(UserManager<AppUser> userManager,
			IGroupReadRepository groupReadRepository,
			IWebHostEnvironment env)
		{
			_userManager = userManager;
			_groupReadRepository = groupReadRepository;
			_env = env;
		}
		public async Task<UpdateStudentCommandResponse> Handle(UpdateStudentCommandRequest request, CancellationToken cancellationToken)
		{
			AppUser? student = _userManager.Users
				.Include(x => x.Groups)
				.FirstOrDefault(
				x => 
				x.IsDeleted == false && x.Id == request.Id
				);

			if (student is null)
				return new() { Success = false, ErrorMessage = "Student doesn't exists !" };

			// check username already take condition
			if (_userManager.Users.FirstOrDefault(
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

			student.FirstName = request.FirstName;
			student.LastName = request.LastName;
			student.Email = request.Email;
			student.UserName = request.UserName;
			student.Adress = request.Adress;
			student.BirthDate = request.BirthDate;
			student.Gender = request.Gender;
			student.DepartmentId = request.DepartmentId;
			student.PhoneNumber = request.Phone;
			
			if (request.Image != null)
				student.ImageSrc = request.Image.Save(_env.WebRootPath, "ProfilePhotos");

			Group? group = student.Groups.FirstOrDefault(x => x.Id == request.GroupId);

			if(group is null)
			{
				Group newGroup = await _groupReadRepository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == request.GroupId);

				if (newGroup is null)
					return new() { Success = false, ErrorMessage = "Group doesn't exists !" };

				student.Groups.Clear();
				student.Groups.Add(newGroup);
			}

			IdentityResult result = await _userManager.UpdateAsync(student);

			if(!result.Succeeded)
				return new() { Success = false, ErrorMessage = result.Errors.FirstOrDefault().Description };

			return new() { Success = true };
		}
	}
}
