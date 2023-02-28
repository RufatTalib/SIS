using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.UserPasswordCommand.UserPasswordUpdate
{
	public class UserPasswordUpdateCommandRequest : IRequest<UserPasswordUpdateCommandResponse>
	{
		[Required]
		[DataType(DataType.Password)]
		public string OldPassword { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare(nameof(NewPassword), ErrorMessage = "Passwords doesn't match !")]
		public string NewPasswordConfirm { get; set; }
	}
}
