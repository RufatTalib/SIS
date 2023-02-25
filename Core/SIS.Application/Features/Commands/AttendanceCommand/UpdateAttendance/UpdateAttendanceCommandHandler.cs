using MediatR;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Repositories.AttendanceRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.AttendanceCommand.UpdateAttendance
{
	public class UpdateAttendanceCommandHandler : IRequestHandler<UpdateAttendanceCommandRequest, UpdateAttendanceCommandResponse>
	{
		private readonly IAttendanceReadRepository _attendanceReadRepository;
		private readonly IAttendanceWriteRepository _attendanceWriteRepository;

		public UpdateAttendanceCommandHandler(IAttendanceReadRepository attendanceReadRepository
			,IAttendanceWriteRepository attendanceWriteRepository)
		{
			_attendanceReadRepository = attendanceReadRepository;
			_attendanceWriteRepository = attendanceWriteRepository;
		}
		public async Task<UpdateAttendanceCommandResponse> Handle(UpdateAttendanceCommandRequest request, CancellationToken cancellationToken)
		{
			List<Attendance> existAttendances = _attendanceReadRepository.GetWhere(
				   x => x.IsDeleted == false && x.LessonEventId == request.LessonId
				   ).Include(x => x.Student).ToList();

			for (int i = 0; i < existAttendances.Count; i++)
			{
				existAttendances[i].State = request.Attendances[i].State;
			}

			_attendanceWriteRepository.UpdateRange(existAttendances);
			_attendanceWriteRepository.Save();

			return new() { Success = true };
		}
	}
}
