using FluentValidation;
using SIS.Application.Features.Commands.BlogCommand.CreateBlog;
using SIS.Application.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Validators.BlogCommandValidators
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommandRequest>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(x => x.Image).SetValidator(new ImageValidator());
        }
    }
}
