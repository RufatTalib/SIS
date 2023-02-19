using Microsoft.EntityFrameworkCore;
using SIS.Application.Repositories;
using SIS.Domain.Entities.Common;
using SIS.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance.Repositories
{
	public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
	{
		private readonly SISDbContext _context;

		public ReadRepository(SISDbContext context)
		{
			_context = context;
		}
		public DbSet<T> Table => _context.Set<T>();

		public bool Any(Expression<Func<T, bool>> expression)
		{
			return Table.Any(expression);
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
		{
			return await Table.AnyAsync(expression);
		}

		public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
		{
			return await Table.FirstOrDefaultAsync<T>(expression);
		}

		public IQueryable<T> GetAll()
		{
			return Table;
		}

		public async Task<T> GetByIdAsync(int Id)
		{
			return await FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
		}

		public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
		{
			return Table.Where(expression);
		}
	}
}
