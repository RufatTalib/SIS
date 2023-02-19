using MediatR;
using SIS.Application.Repositories.DepartmentRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.DepartmentCommand.CreateDepartment
{
	public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommandRequest, CreateDepartmentCommandResponse>
	{
		private readonly IDepartmentWriteRepository _departmentWriteRepository;

		public CreateDepartmentCommandHandler(IDepartmentWriteRepository departmentWriteRepository)
		{
			_departmentWriteRepository = departmentWriteRepository;
		}
		public async Task<CreateDepartmentCommandResponse> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
		{
			if (request == null) return new() { Success = false, ErrorMessage = "Invalid Request" };


			_departmentWriteRepository.Add(new()
			{
				CreatedDate = DateTime.UtcNow,
				Name = request.Name,
				HeadOfDepartment = request.HeadOfDepartment,
				NumberOfStudents = 0,
				StartedDate = request.StartedDate
			});

			_departmentWriteRepository.Save();

			return new() { Success = true };
		}
	}
}
