using MediatR;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Repositories.GroupRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.GroupCommand.DeleteGroup
{
	public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommandRequest, DeleteGroupCommandResponse>
	{
		private readonly IGroupWriteRepository _groupWriteRepository;
		private readonly IGroupReadRepository _groupReadRepository;

		public DeleteGroupCommandHandler(IGroupWriteRepository groupWriteRepository, IGroupReadRepository groupReadRepository)
		{
			_groupWriteRepository = groupWriteRepository;
			_groupReadRepository = groupReadRepository;
		}
		public async Task<DeleteGroupCommandResponse> Handle(DeleteGroupCommandRequest request, CancellationToken cancellationToken)
		{
			Group group = await _groupReadRepository
				.GetWhere(x => x.IsDeleted == false)
				.Include(x => x.LessonEvents)
				.FirstOrDefaultAsync(x => x.Id == request.Id);

			if (group is null)
				return new() { Success = false, ErrorMessage = "Invalid group !" };

			group.LessonEvents.ForEach(x => x.IsDeleted = true);
			
			if (!_groupWriteRepository.Delete(group))
				return new() { Success = false, ErrorMessage = "Delete operation failed !" };

			_groupWriteRepository.Save();

			return new() { Success = true };
		}
	}
}
