using Microsoft.Extensions.DependencyInjection;
using SIS.Persistance.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance
{
	public static class Persistance
	{
		public static void AddPersistances(this IServiceCollection services)
		{
			services.AddScoped<HomeLayoutService>();
			//

		}
	}
}
