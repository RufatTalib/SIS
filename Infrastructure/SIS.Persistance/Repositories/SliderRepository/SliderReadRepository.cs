using SIS.Application.Repositories.SliderRepository;
using SIS.Domain.Entities;
using SIS.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance.Repositories.SliderRepository
{
	public class SliderReadRepository : ReadRepository<Slider>, ISliderReadRepository
	{
		public SliderReadRepository(SISDbContext context) : base(context)
		{
		}
	}
}
