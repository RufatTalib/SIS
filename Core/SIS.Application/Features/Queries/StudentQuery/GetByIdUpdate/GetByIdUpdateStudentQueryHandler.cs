using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Features.Commands.StudentCommand.UpdateStudent;
using SIS.Application.Repositories.DepartmentRepository;
using SIS.Application.Repositories.GroupRepository;
using SIS.Domain.Entities;

namespace SIS.Application.Features.Queries.StudentQuery.GetByIdUpdate
{
	public class GetByIdUpdateStudentQueryHandler : IRequestHandler<GetByIdUpdateStudentQueryRequest, GetByIdUpdateStudentQueryResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IDepartmentReadRepository _departmentReadRepository;
		private readonly IGroupReadRepository _groupReadRepository;

		public GetByIdUpdateStudentQueryHandler(UserManager<AppUser> userManager,
			IDepartmentReadRepository departmentReadRepository,
			IGroupReadRepository groupReadRepository)
		{
			_userManager = userManager;
			_departmentReadRepository = departmentReadRepository;
			_groupReadRepository = groupReadRepository;
		}
		public async Task<GetByIdUpdateStudentQueryResponse> Handle(GetByIdUpdateStudentQueryRequest request, CancellationToken cancellationToken)
		{
			AppUser? Student = await _userManager.Users
				.Include(x => x.Groups)
				.FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == request.Id);

			if (Student == null) return null;

			return new()
			{
				Request = new UpdateStudentCommandRequest()
				{
					Adress = Student.Adress,
					DepartmentId = Student.DepartmentId,
					FirstName = Student.FirstName,
					LastName = Student.LastName,
					UserName = Student.UserName,
					BirthDate = Student.BirthDate,
					Email = Student.Email,
					Gender = Student.Gender,
					Phone = Student.PhoneNumber,
					GroupId = Student.Groups.SingleOrDefault().Id,
					ImageSrc = Student.ImageSrc
				}
			};
		}
	}
}
