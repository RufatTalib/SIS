using MediatR;
using SIS.Application.Repositories.SubjectRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.SubjectCommand.DeleteSubject
{
	public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommandRequest, DeleteSubjectCommandResponse>
	{
		private readonly ISubjectReadRepository _subjectReadRepository;
		private readonly ISubjectWriteRepository _subjectWriteRepository;

		public DeleteSubjectCommandHandler(ISubjectReadRepository subjectReadRepository, ISubjectWriteRepository subjectWriteRepository)
		{
			_subjectReadRepository = subjectReadRepository;
			_subjectWriteRepository = subjectWriteRepository;
		}
		public async Task<DeleteSubjectCommandResponse> Handle(DeleteSubjectCommandRequest request, CancellationToken cancellationToken)
		{
			Subject subject = await _subjectReadRepository.GetByIdAsync(request.Id);

			if (subject == null) return new() { Success = false, ErrorMessage = "Subject not found!" };
			
			subject.IsDeleted = true;

			if( !_subjectWriteRepository.Update(subject)) return new() { Success = false, ErrorMessage = "Update operation failed!" };

			_subjectWriteRepository.Save();

			return new() { Success = true };
		}
	}
}
