using Microsoft.EntityFrameworkCore;
using SIS.Domain.Entities.Common;
/*using SIS.Domain.Interfaces;*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Repositories
{
	public interface IRepository<TEntity> where TEntity : BaseEntity
	{
		DbSet<TEntity> Table { get; }
	}
}
