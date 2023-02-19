using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Extentions
{
	public static class Extentions
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			var assembly = Assembly.GetExecutingAssembly();
			return services.AddMediatR(assembly);
		}

		public static void Save(this IFormFile file, string path)
		{
			using (FileStream fileStream = new FileStream(path, FileMode.Create))
			{
				file.CopyTo(fileStream);
			}
		}

		public static string Save(this IFormFile file, params string[] paths)
		{
			string filename = file.Guidize();
			string path = Path.Combine(Path.Combine(paths), filename);

			// Save the file
			file.Save(path);

			return filename;
		}

		public static string Guidize(this IFormFile file)
		{
			string rawFileName = file.FileName;

			rawFileName = rawFileName.Length > 64 ? rawFileName.Substring(rawFileName.Length - 64, 64) : rawFileName;
			rawFileName = Guid.NewGuid().ToString() + rawFileName;

			return rawFileName;
		}

		public static void DeleteFile(string path)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}

		public static void DeleteFile(params string[] paths)
		{
			DeleteFile(Path.Combine(paths));
		}
	}
}
