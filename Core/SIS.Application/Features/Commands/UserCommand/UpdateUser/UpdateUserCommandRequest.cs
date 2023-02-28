using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.UserCommand.UpdateUser
{
	public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
	{
		public string? UserId { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public string? Adress { get; set; }
		public string? ImageSrc { get; set; }
		public string? JobDescription { get; set; }
		public string? Description { get; set; }
		public DateTime? BirthDate { get; set; }
		public IFormFile? Image { get; set; }
	}
}
