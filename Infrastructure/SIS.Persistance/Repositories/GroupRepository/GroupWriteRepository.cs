using Microsoft.EntityFrameworkCore;
using SIS.Application.Repositories.GroupRepository;
using SIS.Domain.Entities;
using SIS.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance.Repositories.GroupRepository
{
	public class GroupWriteRepository : WriteRepository<Group>, IGroupWriteRepository
	{
		public GroupWriteRepository(SISDbContext context) : base(context)
		{
		}

		public int Save()
		{
			return _context.SaveChanges();
		}
	}
}
