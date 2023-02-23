using MediatR;
using SIS.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.EventCommand.CreateEvent
{
    public class CreateEventCommandRequest : IRequest<CreateEventCommandResponse>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Period Period { get; set; }
    }
}
