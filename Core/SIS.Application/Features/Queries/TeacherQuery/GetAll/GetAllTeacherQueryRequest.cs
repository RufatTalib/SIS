using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.TeacherQuery.GetAll
{
	public class GetAllTeacherQueryRequest : IRequest<GetAllTeacherQueryResponse>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
		public string? SearchByName { get; set; }
		public string? SearchBySurname { get; set; }
		public string? SearchByQualification { get; set; }
		public string? SearchBySubject { get; set; }

	}
}
