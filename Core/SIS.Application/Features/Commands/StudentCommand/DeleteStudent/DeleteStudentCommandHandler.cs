using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.StudentCommand.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommandRequest, DeleteStudentCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public DeleteStudentCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<DeleteStudentCommandResponse> Handle(DeleteStudentCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser student = _userManager.Users.Where(x => x.Id == request.Id
            && x.IsDeleted == false).Include(x => x.Groups).FirstOrDefault();

            if(student is null)
                return new() { Success = false, ErrorMessage = "Student doesn't exists !" };

            student.Groups.ForEach(x => x.IsDeleted = true);
            student.IsDeleted = true;

            IdentityResult result = await _userManager.UpdateAsync(student);

            if(!result.Succeeded)
                return new() { Success = false, ErrorMessage = result.Errors.First().Description };

            return new() { Success = true };
        }
    }
}
