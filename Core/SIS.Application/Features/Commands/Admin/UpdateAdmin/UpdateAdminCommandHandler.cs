using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using SIS.Application.Extentions;
using SIS.Domain.Entities;
using SIS.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.Admin.UpdateAdmin
{
	public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommandRequest, UpdateAdminCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IWebHostEnvironment _env;

		public UpdateAdminCommandHandler(UserManager<AppUser> userManager, IWebHostEnvironment env)
		{
			_userManager = userManager;
			_env = env;
		}
		public async Task<UpdateAdminCommandResponse> Handle(UpdateAdminCommandRequest request, CancellationToken cancellationToken)
		{
			if (request == null) return new() { Success = false, ErrorMessage = "Invalid Request" };

			AppUser user = await _userManager.FindByNameAsync(request.UserName);
			IdentityResult result;

			user.FirstName = request.FirstName;
			user.LastName = request.LastName;
			user.Email = request.Email;
			user.BirthDate = request.BirthDate;
			user.PhoneNumber = request.Phone;
			user.Adress = request.Adress;
			user.JobDescription = request.JobDescription;
			user.Gender = request.Gender;
			user.UserName = request.UserName;
			user.IdentityRoleName = "Administrator";
			user.Department = null;
			user.DepartmentId = null;

			if(request.Image is not null)
				user.ImageSrc = request.Image.Save(_env.WebRootPath, "ProfilePhotos");

			result = await _userManager.UpdateAsync(user);
			
			if (!result.Succeeded)
				return new() { Success = false, ErrorMessage = result.Errors.First().Description };

			return new() { Success = true };
		}
	}
}
