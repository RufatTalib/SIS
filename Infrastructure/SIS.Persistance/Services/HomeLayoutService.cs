using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SIS.Application.Repositories.SettingRepository;
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
        private readonly ISettingReadRepository _settingReadRepository;

        public HomeLayoutService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor,
			ISettingReadRepository settingReadRepository)
		{
			_userManager = userManager;
			_httpContextAccessor = httpContextAccessor;
            _settingReadRepository = settingReadRepository;
        }
		public async Task<AppUser> GetCurrentUser()
		{
			var Identity = _httpContextAccessor.HttpContext.User.Identity;

			if(Identity.IsAuthenticated)
				return await _userManager.FindByNameAsync(Identity.Name);

			return null;
		}

		public async Task<string?> GetLogoImageSrc()
		{
			Setting setting = await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == "Logo");

			return setting?.Value;
		}
	}
}
