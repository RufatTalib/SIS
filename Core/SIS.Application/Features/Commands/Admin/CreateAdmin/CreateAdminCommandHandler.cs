using MediatR;
using Microsoft.AspNetCore.Identity;
using SIS.Application.Features.Commands.Admin.Create;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SIS.Application.Extentions;
using Microsoft.AspNetCore.Hosting;

namespace SIS.Application.Features.Commands.Admin.CreateAdmin
{
	public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommandRequest, CreateAdminCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IWebHostEnvironment _env;

		public CreateAdminCommandHandler(UserManager<AppUser> userManager, IWebHostEnvironment env)
		{
			_userManager = userManager;
			_env = env;
		}

		public async Task<CreateAdminCommandResponse> Handle(CreateAdminCommandRequest request,
			CancellationToken cancellationToken)
		{
			if (request == null) return new() { Success = false, ErrorMessage = "Invalid Request"};

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
				IdentityRoleName = "Administrator",
				Department = null,
				DepartmentId = null,
				ImageSrc = request.Image.Save(_env.WebRootPath, "ProfilePhotos")
			};

			result = await _userManager.CreateAsync(user, request.Password);

			if(!result.Succeeded)
				return new() { Success = false, ErrorMessage = result.Errors.First().Description };

			result = await _userManager.AddToRoleAsync(user, "Admin");

			if(!result.Succeeded)
				return new() { Success = false, ErrorMessage = result.Errors.First().Description };


			return new() { Success = true };
		}


	}
}
