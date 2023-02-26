using SIS.Application.Repositories.SettingRepository;
using SIS.Domain.Entities;
using SIS.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance.Repositories.SettingRepository
{
	public class SettingReadRepository : ReadRepository<Setting>, ISettingReadRepository
	{
		public SettingReadRepository(SISDbContext context) : base(context)
		{
		}
	}
}
