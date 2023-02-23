using MediatR;
using SIS.Application.Repositories.LessonEventRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.LessonEventCommand.DeleteLessonEvent
{
    public class DeleteLessonEventCommandHandler : IRequestHandler<DeleteLessonEventCommandRequest, DeleteLessonEventCommandResponse>
    {
        private readonly ILessonEventReadRepository _lessonEventReadRepository;
        private readonly ILessonEventWriteRepository _lessonEventWriteRepository;

        public DeleteLessonEventCommandHandler(ILessonEventReadRepository lessonEventReadRepository,
            ILessonEventWriteRepository lessonEventWriteRepository)
        {
            _lessonEventReadRepository = lessonEventReadRepository;
            _lessonEventWriteRepository = lessonEventWriteRepository;
        }
        public async Task<DeleteLessonEventCommandResponse> Handle(DeleteLessonEventCommandRequest request, CancellationToken cancellationToken)
        {
            LessonEvent lessonEvent = await _lessonEventReadRepository.GetByIdAsync(request.Id);

            if (lessonEvent == null) return new() { Success = false, ErrorMessage = "Lesson Event doesn't exists !" };

            lessonEvent.IsDeleted = true;
            lessonEvent.RemovedDate = DateTime.UtcNow;

            if(!_lessonEventWriteRepository.Update(lessonEvent))
                return new() { Success = false, ErrorMessage = "Delete operation failed !" };

            _lessonEventWriteRepository.Save();

            return new() { Success= true };
        }
    }
}
