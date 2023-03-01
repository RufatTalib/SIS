using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance
{
	public class DbInitializer
	{
		private readonly ModelBuilder _modelBuilder;
		private static int _settingId = 1;
		public DbInitializer(ModelBuilder modelBuilder)
		{
			_modelBuilder = modelBuilder;

		}

		public Setting NewSetting(string key, string value)
		{
			Setting setting = new Setting()
			{
				Id = _settingId++,
				CreatedDate = DateTime.UtcNow,
				RemovedDate = null,
				IsDeleted = false,
				Key = key,
				Value = value
			};

			return setting;
		}

		public void Seed()
		{
			_modelBuilder.Entity<Setting>().HasData(
				NewSetting("Info", "Example information message"),
				NewSetting("Awards", "100"),
				NewSetting("FacebookFollowerCount", "100"),
				NewSetting("InstagramFollowerCount", "100"),
				NewSetting("TwitterFollowerCount", "100"),
				NewSetting("LinkedInFollowerCount", "100"),
				NewSetting("Adress", "Example Adress"),
				NewSetting("Gmail", "example@gmail.com"),
				NewSetting("Phone", "012 000 00 00"),
				NewSetting("Fax", "012 000 00 00"),
				NewSetting("Name", "Company Name"),
				NewSetting("Logo", "~/assets/img/logo.png")
				);

			_modelBuilder.Entity<AppUser>().HasData(
				new AppUser()
				{
					Id = Guid.NewGuid().ToString(),
					FirstName = "Rufat",
					LastName = "Talib",
					UserName = "rufettalib",
					NormalizedUserName = "RUFETTALIB",
					IdentityRoleName = "SuperAdmin"
				}
				);

			_modelBuilder.Entity<IdentityRole>().HasData(
				new IdentityRole()
				{
					Id = Guid.NewGuid().ToString(),
					Name = "SuperAdmin",
					NormalizedName = "SUPERADMIN"
				},
				new IdentityRole()
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Admin",
					NormalizedName = "ADMIN"
				},
				new IdentityRole()
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Student",
					NormalizedName = "STUDENT"
				},
				new IdentityRole()
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Teacher",
					NormalizedName = "TEACHER"
				}
				);


		}

	}
}
