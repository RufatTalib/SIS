using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.GroupCommand.CreateGroup
{
	public class CreateGroupCommandRequest :  IRequest<CreateGroupCommandResponse>
	{
		[Required(ErrorMessage = "Please, enter group name !")]
		[StringLength(maximumLength: 255, MinimumLength = 2)]
		public string Name { get; set; }
	}
}
