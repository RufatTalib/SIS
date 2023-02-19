using MediatR;
using SIS.Application.Repositories.SubjectRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.SubjectCommand.CreateSubject
{
	public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommandRequest, CreateSubjectCommandResponse>
	{
		private readonly ISubjectReadRepository _subjectReadRepository;
		private readonly ISubjectWriteRepository _subjectWriteRepository;

		public CreateSubjectCommandHandler(ISubjectReadRepository subjectReadRepository, ISubjectWriteRepository subjectWriteRepository)
		{
			_subjectReadRepository = subjectReadRepository;
			_subjectWriteRepository = subjectWriteRepository;
		}

		public async Task<CreateSubjectCommandResponse> Handle(CreateSubjectCommandRequest request, CancellationToken cancellationToken)
		{
			if (_subjectReadRepository.Any(x => x.Name == request.Name))
				return new CreateSubjectCommandResponse() { Success = false, ErrorMessage = "Subject exists!" };

			Subject subject = new Subject
			{
				CreatedDate = DateTime.UtcNow,
				RemovedDate = null,
				IsDeleted = false,
				Name = request.Name
			};

			_subjectWriteRepository.Add(subject);
			_subjectWriteRepository.Save();

			return new CreateSubjectCommandResponse() { Success = true };
		}
	}
}
