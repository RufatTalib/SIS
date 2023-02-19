using SIS.Application.Repositories;
using SIS.Application.Repositories.SubjectRepository;
using SIS.Domain.Entities;
using SIS.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance.Repositories.SubjectRepository
{
	public class SubjectReadRepository : ReadRepository<Subject> , ISubjectReadRepository
	{
		public SubjectReadRepository(SISDbContext context) : base(context)
		{
		}
	}
}
