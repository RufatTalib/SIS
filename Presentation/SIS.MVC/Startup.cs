using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Extentions;
using SIS.Application.Validators;
using SIS.Domain.Entities;
using SIS.Persistance.Contexts;
using SIS.Persistance.Extentions;
using System.Reflection;

namespace SIS.MVC
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRazorPages().AddFluentValidation(
				configuration =>
				configuration.RegisterValidatorsFromAssemblyContaining<LoginVMValidator>()
				);

			services.AddDbContext<SISDbContext>(
				p => p.UseSqlServer(
					_configuration.GetConnectionString("default")
					)
				);

			services.AddIdentity<AppUser, IdentityRole>(
				identity =>
				{
					identity.Password.RequireNonAlphanumeric = false;
					identity.Password.RequireUppercase = true;
					identity.Password.RequireLowercase = true;
					identity.Password.RequireDigit = true;
					identity.Password.RequiredUniqueChars = 0;
					identity.Password.RequiredLength = 8;
				}
				)
				.AddEntityFrameworkStores<SISDbContext>()
				.AddDefaultTokenProviders();

			
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddApplication();

			services.AddPersistances();
			services.AddAuthentication();
			services.AddAuthorization();




		}

		public void Configure(IApplicationBuilder builder, IWebHostEnvironment env)
		{
			// Configure the HTTP request pipeline.
			if (!env.IsDevelopment())
			{
				builder.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				builder.UseHsts();
			}

			builder.UseHttpsRedirection();
			builder.UseStaticFiles();
			
			
			builder.UseAuthentication();
			builder.UseRouting();

			

			builder.UseAuthorization();
			builder.UseEndpoints(
				endpoints =>
				{
					endpoints.MapControllerRoute(
					name: "Manage",
					pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
					);

					endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=home}/{action=index}/{id?}"
					);

					endpoints.MapControllers();
				}

				);




		}

	}
}
