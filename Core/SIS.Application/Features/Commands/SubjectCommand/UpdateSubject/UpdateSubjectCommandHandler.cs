using MediatR;
using SIS.Application.Repositories.SubjectRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.SubjectCommand.UpdateSubject
{
	public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommandRequest, UpdateSubjectCommandResponse>
	{
		private readonly ISubjectReadRepository _subjectReadRepository;
		private readonly ISubjectWriteRepository _subjectWriteRepository;

		public UpdateSubjectCommandHandler(ISubjectReadRepository subjectReadRepository, ISubjectWriteRepository subjectWriteRepository)
		{
			_subjectReadRepository = subjectReadRepository;
			_subjectWriteRepository = subjectWriteRepository;
		}
		public async Task<UpdateSubjectCommandResponse> Handle(UpdateSubjectCommandRequest request, CancellationToken cancellationToken)
		{
			Subject subject = await _subjectReadRepository.FirstOrDefaultAsync(x => x.Id == request.Id && x.IsDeleted == false);

			if(request.Name != subject.Name && _subjectReadRepository.Any(x => x.Name == request.Name))
			{
				// Subject already exists !
				return new UpdateSubjectCommandResponse() { Success = false, ErrorMessage = "Subject already exists!" };
			}

			subject.Name = request.Name;

			_subjectWriteRepository.Update(subject);
			_subjectWriteRepository.Save();

			return new UpdateSubjectCommandResponse() { Success = true };
		}
	}
}
