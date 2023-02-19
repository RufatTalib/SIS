using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.SubjectQuery.GetAll
{
	public class GetAllSubjectQueryResponse
	{
		public PaginatedList<Subject> Subjects { get; set; }
	}
}
