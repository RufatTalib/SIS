using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using SIS.Application.Extentions;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.TeacherCommand.CreateTeacher
{
	public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommandRequest, CreateTeacherCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IWebHostEnvironment _env;

		public CreateTeacherCommandHandler(UserManager<AppUser> userManager, IWebHostEnvironment env)
		{
			_userManager = userManager;
			_env = env;
		}
		public async Task<CreateTeacherCommandResponse> Handle(CreateTeacherCommandRequest request, CancellationToken cancellationToken)
		{
			AppUser user;
			IdentityResult result;

			// Check username exists
			user = await _userManager.FindByNameAsync(request.UserName);
			if (user is not null)
				return new() { Success = false, ErrorMessage = "Username already exists" };

			// Check email exists
			user = await _userManager.FindByEmailAsync(request.Email);
			if (user is not null)
				return new() { Success = false, ErrorMessage = "Email already exists" };

			user = new()
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				BirthDate = request.BirthDate,
				PhoneNumber = request.Phone,
				Adress = request.Adress,
				JobDescription = request.JobDescription,
				Gender = request.Gender,
				UserName = request.UserName,
				IdentityRoleName = "Teacher",
				DepartmentId = request.DepartmentId,
				ImageSrc = request.Image.Save(_env.WebRootPath, "ProfilePhotos")
			};

			result = await _userManager.CreateAsync(user, request.Password);

			if (!result.Succeeded)
				return new() { Success = false, ErrorMessage = result.Errors.First().Description };

			result = await _userManager.AddToRoleAsync(user, "Teacher");

			if (!result.Succeeded)
				return new() { Success = false, ErrorMessage = result.Errors.First().Description };


			return new() { Success = true };
		}
	}
}
