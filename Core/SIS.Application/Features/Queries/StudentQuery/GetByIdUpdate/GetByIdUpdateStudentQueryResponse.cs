using SIS.Application.Features.Commands.StudentCommand.UpdateStudent;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.StudentQuery.GetByIdUpdate
{
	public class GetByIdUpdateStudentQueryResponse
	{
		public UpdateStudentCommandRequest? Request { get; set; }
	}
}
