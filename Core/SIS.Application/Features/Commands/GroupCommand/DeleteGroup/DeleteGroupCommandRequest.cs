using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.GroupCommand.DeleteGroup
{
	public class DeleteGroupCommandRequest : IRequest<DeleteGroupCommandResponse>
	{
		public int Id { get; set; }
	}
}
