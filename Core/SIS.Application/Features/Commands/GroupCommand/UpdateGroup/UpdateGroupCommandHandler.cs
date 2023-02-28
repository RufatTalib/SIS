using MediatR;
using SIS.Application.Repositories.GroupRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.GroupCommand.UpdateGroup
{
	public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommandRequest, UpdateGroupCommandResponse>
	{
		private readonly IGroupReadRepository _groupReadRepository;
		private readonly IGroupWriteRepository _groupWriteRepository;

		public UpdateGroupCommandHandler(IGroupReadRepository groupReadRepository, IGroupWriteRepository groupWriteRepository)
		{
			_groupReadRepository = groupReadRepository;
			_groupWriteRepository = groupWriteRepository;
		}
		public async Task<UpdateGroupCommandResponse> Handle(UpdateGroupCommandRequest request, CancellationToken cancellationToken)
		{
			Group group = await _groupReadRepository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == request.Id);
			
			if (group == null)
				return new() { Success = false, ErrorMessage = "Group not found !" };

			group.Name = request.Name;

			_groupWriteRepository.Update(group);
			_groupWriteRepository.Save();

			return new() { Success = true };
		}
	}
}
