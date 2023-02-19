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
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(b => b.UseStartup<Startup>()) ;
        }

    }
}