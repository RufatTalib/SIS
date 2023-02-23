using Microsoft.Extensions.DependencyInjection;
using SIS.Application.Repositories.AttendanceRepository;
using SIS.Application.Repositories.BlogRepository;
using SIS.Application.Repositories.DepartmentRepository;
using SIS.Application.Repositories.EventRepository;
using SIS.Application.Repositories.GroupRepository;
using SIS.Application.Repositories.LessonEventRepository;
using SIS.Application.Repositories.SliderImageRepository;
using SIS.Application.Repositories.SliderRepository;
using SIS.Application.Repositories.SubjectRepository;
using SIS.Persistance.Repositories.AttendanceRepository;
using SIS.Persistance.Repositories.BlogRepository;
using SIS.Persistance.Repositories.DepartmentRepository;
using SIS.Persistance.Repositories.EventRepository;
using SIS.Persistance.Repositories.GroupRepository;
using SIS.Persistance.Repositories.LessonEventRepository;
using SIS.Persistance.Repositories.SliderImageRepository;
using SIS.Persistance.Repositories.SliderRepository;
using SIS.Persistance.Repositories.SubjectRepository;
using SIS.Persistance.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance.Extentions
{
	public static class Extentions
	{
		public static void AddPersistances(this IServiceCollection services)
		{
			services.AddScoped<HomeLayoutService>();
			
			services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
			services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();

			services.AddScoped<ISubjectReadRepository, SubjectReadRepository>();
			services.AddScoped<ISubjectWriteRepository, SubjectWriteRepository>();

			services.AddScoped<IBlogReadRepository, BlogReadRepository>();
			services.AddScoped<IBlogWriteRepository, BlogWriteRepository>();

			services.AddScoped<ISliderReadRepository, SliderReadRepository>();
			services.AddScoped<ISliderWriteRepository, SliderWriteRepository>();

			services.AddScoped<ISliderImageReadRepository, SliderImageReadRepository>();
			services.AddScoped<ISliderImageWriteRepository, SliderImageWriteRepository>();

			services.AddScoped<IGroupReadRepository, GroupReadRepository>();
			services.AddScoped<IGroupWriteRepository, GroupWriteRepository>();

			services.AddScoped<IEventReadRepository, EventReadRepository>();
			services.AddScoped<IEventWriteRepository, EventWriteRepository>();

			services.AddScoped<ILessonEventReadRepository, LessonEventReadRepository>();
			services.AddScoped<ILessonEventWriteRepository, LessonEventWriteRepository>();

			services.AddScoped<IAttendanceReadRepository, AttendanceReadRepository>();
			services.AddScoped<IAttendanceWriteRepository, AttendanceWriteRepository>();

		}
	}
}
