using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.SubjectCommand.CreateSubject
{
	public class CreateSubjectCommandRequest : IRequest<CreateSubjectCommandResponse>
	{
		[Required(ErrorMessage = "Please, enter subject name !")]
		[StringLength(maximumLength: 60, MinimumLength = 3)]
		public string Name { get; set; }
	}
}
