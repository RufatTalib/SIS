using MediatR;
using SIS.Application.Repositories.EventRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.EventCommand.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommandRequest, DeleteEventCommandResponse>
    {
        private readonly IEventReadRepository _eventReadRepository;
        private readonly IEventWriteRepository _eventWriteRepository;

        public DeleteEventCommandHandler(IEventReadRepository eventReadRepository, IEventWriteRepository eventWriteRepository)
        {
            _eventReadRepository = eventReadRepository;
            _eventWriteRepository = eventWriteRepository;
        }
        public async Task<DeleteEventCommandResponse> Handle(DeleteEventCommandRequest request, CancellationToken cancellationToken)
        {
            Event model = await _eventReadRepository.GetByIdAsync(request.Id);

            if(model is null)
                return new() { Success = false, ErrorMessage = "Event doesn't exist !" };

            model.IsDeleted = true;
            model.RemovedDate = DateTime.UtcNow;

            if (!_eventWriteRepository.Update(model))
                return new() { Success = false, ErrorMessage = "Update operation failed !" };

            _eventWriteRepository.Save();

            return new() { Success = true };
        }
    }
}
