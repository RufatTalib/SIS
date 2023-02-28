using MediatR;
using Microsoft.AspNetCore.Identity;
using SIS.Application.Repositories.LessonEventRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.LessonEventCommand.UpdateLessonEvent
{
	public class UpdateLessonEventCommandHandler : IRequestHandler<UpdateLessonEventCommandRequest,
		UpdateLessonEventCommandResponse>
	{
		private readonly ILessonEventReadRepository _lessonEventReadRepository;
		private readonly ILessonEventWriteRepository _lessonEventWriteRepository;
		private readonly UserManager<AppUser> _userManager;

		public UpdateLessonEventCommandHandler(ILessonEventReadRepository lessonEventReadRepository,
			ILessonEventWriteRepository lessonEventWriteRepository,
			UserManager<AppUser> userManager)
		{
			_lessonEventReadRepository = lessonEventReadRepository;
			_lessonEventWriteRepository = lessonEventWriteRepository;
			_userManager = userManager;
		}
		public async Task<UpdateLessonEventCommandResponse> Handle(UpdateLessonEventCommandRequest request, CancellationToken cancellationToken)
		{
			AppUser teacher = null;

			if (request.TeacherId != null)
			{
				teacher = await _userManager.FindByIdAsync(request.TeacherId);

				if (teacher == null) return new() { Success = false, ErrorMessage = "Invalid teacher !" };
			}
			

			LessonEvent lessonEvent = await _lessonEventReadRepository.FirstOrDefaultAsync(x => x.IsDeleted == false
			&& x.Id == request.Id);

			if (lessonEvent == null) return new() { Success = false, ErrorMessage = "Lesson Event doesn't exist !" };

			lessonEvent.StartedDate = request.StartDate;
			lessonEvent.EndDate = request.EndDate;
			lessonEvent.Name = request.Name;
			lessonEvent.ClassNumber = request.ClassNumber;
			lessonEvent.GroupId = request.GroupId;
			lessonEvent.SubjectId = request.SubjectId;
			lessonEvent.Period = request.Period;
			lessonEvent.Teacher = teacher;

			if (!_lessonEventWriteRepository.Update(lessonEvent))
				return new() { Success = false, ErrorMessage = "Update operation failed !" };

			_lessonEventWriteRepository.Save();

			return new() { Success = true };
		}
	}
}
