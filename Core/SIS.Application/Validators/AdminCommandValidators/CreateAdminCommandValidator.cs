using FluentValidation;
using SIS.Application.Features.Commands.Admin.Create;
using SIS.Application.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Validators.AdminCommandValidators
{
	public class CreateAdminCommandValidator : AbstractValidator<CreateAdminCommandRequest>
	{
		public CreateAdminCommandValidator()
		{
			RuleFor(x => x.Image).SetValidator(new ImageValidator());
		}

	}
}
