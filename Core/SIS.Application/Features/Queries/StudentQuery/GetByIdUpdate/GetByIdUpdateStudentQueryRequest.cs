using MediatR;
using SIS.Application.Features.Commands.StudentCommand.UpdateStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.StudentQuery.GetByIdUpdate
{
	public class GetByIdUpdateStudentQueryRequest : IRequest<GetByIdUpdateStudentQueryResponse>
	{
		public string Id { get; set; }
	}
}
