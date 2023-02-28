using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SIS.Application.Extentions;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.UserCommand.UpdateUser
{
	public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IWebHostEnvironment _env;

		public UpdateUserCommandHandler(UserManager<AppUser> userManager,
			IHttpContextAccessor httpContextAccessor,
			IWebHostEnvironment env)
		{
			_userManager = userManager;
			_httpContextAccessor = httpContextAccessor;
			_env = env;
		}

		public async Task<AppUser?> GetUser()
		{
			if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
				return await _userManager.FindByNameAsync(
					_httpContextAccessor.HttpContext.User.Identity.Name
					);

			return null;
		}

		public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
		{
			AppUser user = await GetUser();

			if (user is null)
				return new() { Success = false, ErrorMessage = "User is not found !" };

			user.FirstName = request.FirstName;
			user.LastName = request.LastName;
			user.Email = request.Email;
			user.PhoneNumber = request.Phone;
			user.BirthDate = request.BirthDate;
			user.Adress = request.Adress;
/*			user.Description = request.Description;
			user.JobDescription = request.JobDescription;
*/			user.ImageSrc = request.Image.Save(_env.WebRootPath, "ProfilePhotos");

			var result = await _userManager.UpdateAsync(user);

			if (!result.Succeeded)
				return new() { Success = false, ErrorMessage = result.Errors.FirstOrDefault().Description };


			return new() { Success = true };
		}
	}
}
