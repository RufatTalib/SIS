using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.SubjectCommand.UpdateSubject
{
	public class UpdateSubjectCommandRequest : IRequest<UpdateSubjectCommandResponse>
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Please, enter subject name !")]
		[StringLength(maximumLength: 60, MinimumLength = 3)]
		public string Name { get; set; }
	}
}
