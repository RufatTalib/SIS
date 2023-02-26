using MediatR;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Features.Commands.SettingCommand.UpdateSetting;
using SIS.Application.Repositories.SettingRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.SettingQuery.GetAll
{
	public class GetAllSettingQueryHandler : IRequestHandler<GetAllSettingQueryRequest, GetAllSettingQueryResponse>
	{
		private readonly ISettingReadRepository _settingReadRepository;

		public GetAllSettingQueryHandler(ISettingReadRepository settingReadRepository)
		{
			_settingReadRepository = settingReadRepository;
		}
		public async Task<GetAllSettingQueryResponse> Handle(GetAllSettingQueryRequest request, CancellationToken cancellationToken)
		{
			UpdateSettingCommandRequest response = new()
			{
				Adress = (await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == "Adress")).Value,
				FacebookFollowerCount = Int32.Parse((await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == "FacebookFollowerCount")).Value),
				InstagramFollowerCount = Int32.Parse((await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == "InstagramFollowerCount")).Value),
				TwitterFollowerCount = Int32.Parse((await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == "TwitterFollowerCount")).Value),
				LinkedInFollowerCount = Int32.Parse((await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == "LinkedInFollowerCount")).Value),
				Gmail = (await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == "Gmail")).Value,
				Phone = (await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == "Phone")).Value,
				Fax = (await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == "Fax")).Value,
				CompanyName = (await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == "Name")).Value,
				LogoUrl = (await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == "Logo")).Value,
				AwardCount = Int32.Parse((await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == "Awards")).Value),
				CompanyDescription = (await _settingReadRepository.FirstOrDefaultAsync(x => x.Key == "Info")).Value
			};

			return new() {
				Request = response
			};
		}
	}
}
