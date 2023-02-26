using MediatR;
using SIS.Application.Repositories.SettingRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.SettingQuery.GetForHome
{
	public class GetForHomeSettingQueryHandler : IRequestHandler<GetForHomeSettingQueryRequest, GetForHomeSettingQueryResponse>
	{
		private readonly ISettingReadRepository _settingReadRepository;

		public GetForHomeSettingQueryHandler(ISettingReadRepository settingReadRepository)
		{
			_settingReadRepository = settingReadRepository;
		}
		public async Task<GetForHomeSettingQueryResponse> Handle(GetForHomeSettingQueryRequest request, CancellationToken cancellationToken)
		{
			return new()
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
		}
	}
}
