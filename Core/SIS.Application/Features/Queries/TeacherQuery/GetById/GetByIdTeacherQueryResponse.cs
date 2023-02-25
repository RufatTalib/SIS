using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.TeacherQuery.GetById
{
	public class GetByIdTeacherQueryResponse
	{
		public AppUser? Teacher { get; set; }
	}
}
