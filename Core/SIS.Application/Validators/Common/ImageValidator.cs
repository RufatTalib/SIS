using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Validators.Common
{
	public class ImageValidator : AbstractValidator<IFormFile>
	{
		public ImageValidator()
		{
			RuleFor(x => x.Length)
				.NotNull()
				.LessThanOrEqualTo(5242880) // 5 MB
				.WithMessage("File size is larger than allowed");

			RuleFor(x => x.ContentType)
				.NotNull()
				.Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
				.WithMessage("File format is not acceptable");
		}
	}
}
