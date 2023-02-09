using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIS.Domain.Entities;
using SIS.Persistance.Contexts;
using FluentValidation.AspNetCore;
using SIS.Application.Validators;
using SIS.Persistance;

namespace SIS.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

/*            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();*/

            // Add services to the container.
            builder.Services.AddRazorPages().AddFluentValidation(
                configuration =>
                configuration.RegisterValidatorsFromAssemblyContaining<LoginVMValidator>()
                );

            builder.Services.AddDbContext<SISDbContext>(
                p => p.UseSqlServer(
                    builder.Configuration.GetConnectionString("default")
                    )
                );

            builder.Services.AddIdentity<AppUser, IdentityRole>(
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

            builder.Services.AddPersistances();

            /*builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
*/

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name:"Manage",
                pattern:"{area:exists}/{controller=dashboard}/{action=index}/{id?}"
                );

            app.MapControllerRoute(
                name:"default",
                pattern:"{controller=home}/{action=index}/{id?}"
                );

            app.Run();
        }
    }
}