using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.UserPasswordCommand.UserPasswordUpdate
{
	public class UserPasswordUpdateCommandHandler : IRequestHandler<UserPasswordUpdateCommandRequest, 
		UserPasswordUpdateCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserPasswordUpdateCommandHandler(
			UserManager<AppUser> userManager,
			IHttpContextAccessor httpContextAccessor
			)
		{
			_userManager = userManager;
			_httpContextAccessor = httpContextAccessor;
		}
		public async Task<AppUser?> GetCurrentUser()
		{
			if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
				return await _userManager.FindByNameAsync(
					_httpContextAccessor.HttpContext.User.Identity.Name
					);

			return null;
		}

		public async Task<UserPasswordUpdateCommandResponse> Handle(UserPasswordUpdateCommandRequest request, CancellationToken cancellationToken)
		{
			AppUser user = await GetCurrentUser();

			if(user == null)
				return new() { Success= false, ErrorMessage = "User cannot found !" };

			var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

			if (!result.Succeeded)
				return new() { Success = false, ErrorMessage = result.Errors.FirstOrDefault().Description };

			return new() { Success = true };
		}
	}
}
