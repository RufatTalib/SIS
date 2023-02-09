using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SIS.Application.Services;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance.Services
{
	public class HomeLayoutService : IHomeLayoutService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public HomeLayoutService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
		{
			_userManager = userManager;
			_httpContextAccessor = httpContextAccessor;
		}
		public async Task<AppUser> GetCurrentUser()
		{
			var Identity = _httpContextAccessor.HttpContext.User.Identity;

			if(Identity.IsAuthenticated)
				return await _userManager.FindByNameAsync(Identity.Name);

			return null;
		}
	}
}
