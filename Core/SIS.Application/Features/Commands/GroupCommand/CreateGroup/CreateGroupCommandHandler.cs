using MediatR;
using SIS.Application.Repositories.GroupRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.GroupCommand.CreateGroup
{
	public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommandRequest, CreateGroupCommandResponse>
	{
		private readonly IGroupReadRepository _groupReadRepository;
		private readonly IGroupWriteRepository _groupWriteRepository;

		public CreateGroupCommandHandler(IGroupReadRepository groupReadRepository, IGroupWriteRepository groupWriteRepository)
		{
			_groupReadRepository = groupReadRepository;
			_groupWriteRepository = groupWriteRepository;
		}
		public async Task<CreateGroupCommandResponse> Handle(CreateGroupCommandRequest request, CancellationToken cancellationToken)
		{
			Group group = await _groupReadRepository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.Name == request.Name);
			if (group is not null)
				return new() { Success = false, ErrorMessage = "Group already exists !" };

			group = new()
			{
				CreatedDate = DateTime.Now,
				IsDeleted = false,
				RemovedDate = null,
				Name = request.Name
			};

			if (!_groupWriteRepository.Add(group))
				return new() { Success = false, ErrorMessage = "Create operation failed !" };

			_groupWriteRepository.Save();

			return new() { Success = true };
		}
	}
}
