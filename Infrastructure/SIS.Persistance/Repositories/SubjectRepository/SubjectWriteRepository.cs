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
	public class SubjectWriteRepository : WriteRepository<Subject>, ISubjectWriteRepository
	{
		public SubjectWriteRepository(SISDbContext context) : base(context)
		{
		}
	}
}
