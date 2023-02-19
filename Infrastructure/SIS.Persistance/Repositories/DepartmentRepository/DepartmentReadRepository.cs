using SIS.Application.Repositories.DepartmentRepository;
using SIS.Domain.Entities;
using SIS.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance.Repositories.DepartmentRepository
{
	public class DepartmentReadRepository : ReadRepository<Department>, IDepartmentReadRepository
	{
		public DepartmentReadRepository(SISDbContext context) : base(context)
		{
		}
	}
}
