using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.DepartmentCommand.CreateDepartment
{
	public class CreateDepartmentCommandRequest : IRequest<CreateDepartmentCommandResponse>
	{
		[Required(ErrorMessage = "Please, enter department name !")]
		[StringLength(maximumLength: 60, MinimumLength = 3)]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please, enter Head of Department !")]
		[StringLength(maximumLength: 50, MinimumLength = 5)]
		public string HeadOfDepartment { get; set; }

		[Required(ErrorMessage = "Please, enter started date !")]
		[DataType(DataType.Date)]
		public DateTime StartedDate { get; set; }
	}
}
