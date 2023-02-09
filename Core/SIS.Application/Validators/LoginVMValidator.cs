using FluentValidation;
using SIS.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Validators
{
	public class LoginVMValidator : AbstractValidator<LoginVM>
	{
		public LoginVMValidator()
		{
			RuleFor(m => m.UserName)
				.NotEmpty()
				.NotNull()
				.WithMessage("Please, enter username !")
				.MinimumLength(4)
				.MaximumLength(50)
				.WithMessage("Username length must be range 4 to 50");

			RuleFor(m => m.Password)
				.NotEmpty()
				.NotNull()
				.WithMessage("Please, enter password !")
				.MinimumLength(8)
				.MaximumLength(60)
				.WithMessage("Password length must be range 8 to 60");
		}

	}
}
