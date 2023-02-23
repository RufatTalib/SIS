using MediatR;
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

        public CreateLessonEventCommandHandler(ILessonEventWriteRepository lessonEventWriteRepository)
        {
            _lessonEventWriteRepository = lessonEventWriteRepository;
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

            _lessonEventWriteRepository.Save();

            return new() { Success = true };
        }
    }
}
