using MediatR;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Repositories.AttendanceRepository;
using SIS.Application.Repositories.GroupRepository;
using SIS.Application.Repositories.LessonEventRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.LessonEventCommand.CreateLessonEvent
{
    public class CreateLessonEventCommandHandler : IRequestHandler<CreateLessonEventCommandRequest, CreateLessonEventCommandResponse>
    {
        private readonly ILessonEventWriteRepository _lessonEventWriteRepository;
		private readonly IAttendanceWriteRepository _attendanceWriteRepository;
		private readonly IGroupReadRepository _groupReadRepository;

		public CreateLessonEventCommandHandler(ILessonEventWriteRepository lessonEventWriteRepository,
            IAttendanceWriteRepository attendanceWriteRepository,
            IGroupReadRepository groupReadRepository)
        {
            _lessonEventWriteRepository = lessonEventWriteRepository;
			_attendanceWriteRepository = attendanceWriteRepository;
			_groupReadRepository = groupReadRepository;
		}
        public async Task<CreateLessonEventCommandResponse> Handle(CreateLessonEventCommandRequest request, CancellationToken cancellationToken)
        {
            LessonEvent lessonEvent = new()
            {
                CreatedDate = DateTime.UtcNow,
                RemovedDate = null,
                IsDeleted = false,
                StartedDate = request.StartDate,
                EndDate = request.EndDate,
                Name = request.Name,
                Period = request.Period,
                GroupId = request.GroupId,
                SubjectId = request.SubjectId,
                ClassNumber = request.ClassNumber
            };

            if (!_lessonEventWriteRepository.Add(lessonEvent))
                return new() { Success = false, ErrorMessage = "Create operation failed !" };

            Group group = await _groupReadRepository.GetWhere(x => x.IsDeleted == false
            && x.Id == request.GroupId).Include(x => x.Users).FirstOrDefaultAsync();

            List<Attendance> attendances = new();
            group.Users.ForEach(
                x =>
                {

                    attendances.Add(new Attendance
                    {
                        CreatedDate= DateTime.UtcNow,
                        RemovedDate = null,
                        IsDeleted = false,
                        LessonEvent = lessonEvent,
                        Student = x
                    });

                });

            _attendanceWriteRepository.AddRange(attendances);

            _lessonEventWriteRepository.Save();
            _attendanceWriteRepository.Save();

            return new() { Success = true };
        }
    }
}
