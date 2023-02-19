using MediatR;
using Microsoft.AspNetCore.Http;
using SIS.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.Admin.UpdateAdmin
{
	public class UpdateAdminCommandRequest : IRequest<UpdateAdminCommandResponse>
	{
		[Required(ErrorMessage = "Please, enter firstname !")]
		[StringLength(maximumLength: 50, MinimumLength = 2)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Please, enter lastname !")]
		[StringLength(maximumLength: 50, MinimumLength = 2)]
		public string LastName { get; set; }


		[Required(ErrorMessage = "Please, enter username !")]
		[StringLength(maximumLength: 30, MinimumLength = 6)]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Please, enter your email adress !")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please, enter your phone number !")]
		[DataType(DataType.PhoneNumber)]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Please, enter address !")]
		[StringLength(maximumLength: 255)]
		public string Adress { get; set; }

		[Required(ErrorMessage = "Please, enter job description !")]
		[StringLength(maximumLength: 255)]
		public string JobDescription { get; set; }

		public Gender? Gender { get; set; }

		[Required(ErrorMessage = "Please, enter your birthdate !")]
		[DataType(DataType.Date)]
		public DateTime? BirthDate { get; set; }

		public IFormFile? Image { get; set; }
	}
}
