using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.StudentQuery.GetById
{
	public class GetByIdStudentQueryResponse
	{
		public AppUser? Student { get; set; }
	}
}
