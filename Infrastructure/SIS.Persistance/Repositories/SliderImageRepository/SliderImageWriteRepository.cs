using SIS.Application.Repositories.SliderImageRepository;
using SIS.Domain.Entities;
using SIS.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance.Repositories.SliderImageRepository
{
	public class SliderImageWriteRepository : WriteRepository<SliderImage>, ISliderImageWriteRepository
	{
		public SliderImageWriteRepository(SISDbContext context) : base(context)
		{
		}
	}
}
