using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.EventCommand.DeleteEvent
{
    public class DeleteEventCommandRequest : IRequest<DeleteEventCommandResponse>
    {
        public int Id { get; set; }
    }
}
