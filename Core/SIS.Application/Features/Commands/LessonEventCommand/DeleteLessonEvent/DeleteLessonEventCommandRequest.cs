using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.LessonEventCommand.DeleteLessonEvent
{
    public class DeleteLessonEventCommandRequest : IRequest<DeleteLessonEventCommandResponse>
    {
        public int Id { get; set; }
    }
}
