using MediatR;
using Microsoft.AspNetCore.Hosting;
using SIS.Application.Extentions;
using SIS.Application.Repositories.SettingRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.SettingCommand.UpdateSetting
{
	public class UpdateSettingCommandHandler : IRequestHandler<UpdateSettingCommandRequest, UpdateSettingCommandResponse>
	{
		private readonly ISettingReadRepository _settingReadRepository;
		private readonly ISettingWriteRepository _settingWriteRepository;
		private readonly IWebHostEnvironment _env;

		public UpdateSettingCommandHandler(ISettingReadRepository settingReadRepository,
			ISettingWriteRepository settingWriteRepository,
			IWebHostEnvironment env)
		{
			_settingReadRepository = settingReadRepository;
			_settingWriteRepository = settingWriteRepository;
			_env = env;
		}
		public async Task<UpdateSettingCommandResponse> Handle(UpdateSettingCommandRequest request, CancellationToken cancellationToken)
		{
			Setting setting;

			if(request.Logo!= null) 
			{
				setting = await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == "Logo");

				if (setting is null)
					return new() { Success = false, ErrorMessage = "Invalid setting !" };

				setting.Value = request.Logo.Save(_env.WebRootPath, "Settings");
			}

			if (await Update("Info", request.CompanyDescription) is not true) return new() { Success = false, ErrorMessage = "Update operation failed !" };
			if (await Update("Awards", request.AwardCount) is not true) return new() { Success = false, ErrorMessage = "Update operation failed !" };
			if (await Update("FacebookFollowerCount", request.FacebookFollowerCount) is not true) return new() { Success = false, ErrorMessage = "Update operation failed !" };
			if (await Update("InstagramFollowerCount", request.InstagramFollowerCount) is not true) return new() { Success = false, ErrorMessage = "Update operation failed !" };
			if (await Update("TwitterFollowerCount", request.TwitterFollowerCount) is not true) return new() { Success = false, ErrorMessage = "Update operation failed !" };
			if (await Update("LinkedInFollowerCount", request.LinkedInFollowerCount) is not true) return new() { Success = false, ErrorMessage = "Update operation failed !" };
			if (await Update("Gmail", request.Gmail) is not true) return new() { Success = false, ErrorMessage = "Update operation failed !" };
			if (await Update("Adress", request.Adress) is not true) return new() { Success = false, ErrorMessage = "Update operation failed !" };
			if (await Update("Phone", request.Phone) is not true) return new() { Success = false, ErrorMessage = "Update operation failed !" };
			if (await Update("Fax", request.Fax) is not true) return new() { Success = false, ErrorMessage = "Update operation failed !" };
			if (await Update("Name", request.CompanyName) is not true) return new() { Success = false, ErrorMessage = "Update operation failed !" };

			_settingWriteRepository.Save();

			return new() { Success = true };
		}

		public async Task<bool> Update(string key, string value)
		{
			Setting setting = await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == key);
			if (setting != null)
				setting.Value = value;
			else
				return false;

			_settingWriteRepository.Update(setting);

			return true;
		}

		public async Task<bool> Update(string key, int value)
		{
			Setting setting = await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == key);
			if (setting != null)
				setting.Value = value.ToString();
			else
				return false;

			return true;
		}
	}
}
