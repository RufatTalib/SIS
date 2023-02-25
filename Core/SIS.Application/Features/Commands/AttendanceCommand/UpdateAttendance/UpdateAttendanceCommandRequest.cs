using MediatR;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.AttendanceCommand.UpdateAttendance
{
	public class UpdateAttendanceCommandRequest : IRequest<UpdateAttendanceCommandResponse>
	{
		public List<Attendance> Attendances { get; set; }
		public int? LessonId { get; set; }
	}
}
