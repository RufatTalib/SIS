using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.GroupCommand.UpdateGroup
{
	public class UpdateGroupCommandRequest : IRequest<UpdateGroupCommandResponse>
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Please, enter group name !")]
		[StringLength(maximumLength: 255, MinimumLength = 2)]
		public string Name { get; set; }
	}
}
