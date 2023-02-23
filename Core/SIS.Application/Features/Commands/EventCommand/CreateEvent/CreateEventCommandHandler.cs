using MediatR;
using SIS.Application.Repositories.EventRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.EventCommand.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommandRequest, CreateEventCommandResponse>
    {
        private readonly IEventWriteRepository _eventWriteRepository;

        public CreateEventCommandHandler(IEventWriteRepository eventWriteRepository)
        {
            _eventWriteRepository = eventWriteRepository;
        }
        public async Task<CreateEventCommandResponse> Handle(CreateEventCommandRequest request, CancellationToken cancellationToken)
        {
            Event newEvent = new Event()
            {
                CreatedDate = DateTime.UtcNow,
                RemovedDate = null,
                IsDeleted = false,
                Name = request.Name,
                StartedDate = request.StartDate,
                EndDate = request.EndDate,
                Period = request.Period
            };

            if (!_eventWriteRepository.Add(newEvent))
                return new() { Success = false, ErrorMessage = "Create operation failed !" };

            _eventWriteRepository.Save();

            return new() { Success = true };
        }
    }
}
