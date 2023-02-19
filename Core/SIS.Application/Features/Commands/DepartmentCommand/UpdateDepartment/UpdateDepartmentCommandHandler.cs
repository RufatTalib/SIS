using MediatR;
using SIS.Application.Repositories.DepartmentRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.DepartmentCommand.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommandRequest, UpdateDepartmentCommandResponse>
    {
        private readonly IDepartmentWriteRepository _departmentWriteRepository;
        private readonly IDepartmentReadRepository _departmentReadRepository;

        public UpdateDepartmentCommandHandler(IDepartmentWriteRepository departmentWriteRepository, IDepartmentReadRepository departmentReadRepository)
        {
            _departmentWriteRepository = departmentWriteRepository;
            _departmentReadRepository = departmentReadRepository;
        }
        public async Task<UpdateDepartmentCommandResponse> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            Department department = await _departmentReadRepository.FirstOrDefaultAsync(x => x.Id == request.Id && x.IsDeleted == false);

            department.HeadOfDepartment = request.HeadOfDepartment;
            department.StartedDate = request.StartedDate;
            department.Name = request.Name;

            _departmentWriteRepository.Update(department);
            _departmentWriteRepository.Save();

            return new() { Success = true };
        }
    }
}
