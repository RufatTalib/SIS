using MediatR;
using SIS.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.LessonEventCommand.UpdateLessonEvent
{
	public class UpdateLessonEventCommandRequest : IRequest<UpdateLessonEventCommandResponse>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public Period Period { get; set; }
		public int GroupId { get; set; }
		public int SubjectId { get; set; }
		public int ClassNumber { get; set; }
		public string? TeacherId { get; set; }
	}
}
