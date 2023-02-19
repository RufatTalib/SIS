using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.SubjectCommand.DeleteSubject
{
	public class DeleteSubjectCommandRequest : IRequest<DeleteSubjectCommandResponse>
	{
		public int Id { get; set; }
	}
}
