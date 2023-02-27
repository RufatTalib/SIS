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

namespace SIS.Application.Features.Commands.StudentCommand.CreateStudent
{
	public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommandRequest, CreateStudentCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IWebHostEnvironment _env;
		private readonly IGroupReadRepository _groupReadRepository;

		public CreateStudentCommandHandler(UserManager<AppUser> userManager, IWebHostEnvironment env, IGroupReadRepository groupReadRepository)
		{
			_userManager = userManager;
			_env = env;
			_groupReadRepository = groupReadRepository;
		}
		public async Task<CreateStudentCommandResponse> Handle(CreateStudentCommandRequest request, CancellationToken cancellationToken)
		{
			AppUser user;
			IdentityResult result;

			Group group = _groupReadRepository.GetWhere(x => x.IsDeleted == false
			&& x.Id == request.GroupId
			).Include(x => x.Users).First();

			if (group is null)
				return new() { Success = false, ErrorMessage = "Group doesn't exists !" };

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
				JobDescription = "Student",
				Gender = request.Gender,
				UserName = request.UserName,
				IdentityRoleName = "Student",
				DepartmentId = request.DepartmentId,
				ImageSrc = request.Image.Save(_env.WebRootPath, "ProfilePhotos")
			};

			result = await _userManager.CreateAsync(user, request.Password);

			if (!result.Succeeded)
				return new() { Success = false, ErrorMessage = result.Errors.First().Description };

			result = await _userManager.AddToRoleAsync(user, "Student");

			if (!result.Succeeded)
				return new() { Success = false, ErrorMessage = result.Errors.First().Description };


			group.Users.Add(user);
			_groupReadRepository.Save();

			return new() { Success = true };
		}
	}
}
