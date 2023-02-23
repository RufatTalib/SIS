using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Repositories.GroupRepository
{
	public interface IGroupReadRepository : IReadRepository<Group>
	{
		public int Save();
		
	}
}
