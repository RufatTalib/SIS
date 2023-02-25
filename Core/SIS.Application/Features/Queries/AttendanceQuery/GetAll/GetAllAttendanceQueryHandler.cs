using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Repositories.AttendanceRepository;
using SIS.Domain.Entities;

namespace SIS.Application.Features.Queries.AttendanceQuery.GetAll
{
	public class GetAllAttendanceQueryHandler : IRequestHandler<GetAllAttendanceQueryRequest, GetAllAttendanceQueryResponse>
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly UserManager<AppUser> _userManager;
		private readonly IAttendanceReadRepository _attendanceReadRepository;

		public GetAllAttendanceQueryHandler(IHttpContextAccessor httpContextAccessor,
			UserManager<AppUser> userManager,
			IAttendanceReadRepository attendanceReadRepository)
		{
			_httpContextAccessor = httpContextAccessor;
			_userManager = userManager;
			_attendanceReadRepository = attendanceReadRepository;
		}
		public async Task<GetAllAttendanceQueryResponse> Handle(GetAllAttendanceQueryRequest request, CancellationToken cancellationToken)
		{
			string username = _httpContextAccessor.HttpContext.User.Identity.Name;

			AppUser? teacher = await _userManager.Users
				.Where(x => x.IsDeleted == false && x.UserName == username)
				.Include(x => x.LessonEvents)
				.FirstOrDefaultAsync();

			LessonEvent lessonEvent = teacher.LessonEvents.FirstOrDefault(
				x => x.IsDeleted == false
				&& x.StartedDate <= DateTime.UtcNow
				&& DateTime.UtcNow <= x.EndDate
			);

			if(lessonEvent == null )
				return new() { Attendances = null, LessonId = null };

			List<Attendance> attendances = _attendanceReadRepository.GetWhere(
					x => x.IsDeleted == false && x.LessonEventId == lessonEvent.Id
					).Include(x => x.Student).ToList();

			return new() { Attendances = attendances, LessonId = lessonEvent.Id };
		}

	}
}
