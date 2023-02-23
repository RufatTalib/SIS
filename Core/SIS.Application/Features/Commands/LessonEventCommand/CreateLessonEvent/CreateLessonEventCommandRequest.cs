using MediatR;
using SIS.Domain.Entities;
using SIS.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.LessonEventCommand.CreateLessonEvent
{
    public class CreateLessonEventCommandRequest : IRequest<CreateLessonEventCommandResponse>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Period Period { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public int ClassNumber { get; set; }
    }
}
