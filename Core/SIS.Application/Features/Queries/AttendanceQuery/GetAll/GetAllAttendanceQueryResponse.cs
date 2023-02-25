using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.AttendanceQuery.GetAll
{
	public class GetAllAttendanceQueryResponse
	{
		public List<Attendance>? Attendances { get; set; }
		public int? LessonId { get; set; }
	}
}
