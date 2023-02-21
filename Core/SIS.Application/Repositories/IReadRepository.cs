using SIS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Repositories
{
	public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
	{
		IQueryable<T> GetAll();
		IQueryable<T> GetWhere(Expression<Func<T,bool>> expression);
		bool Any(Expression<Func<T, bool>> expression);
		IQueryable<T> AsQueryable();
		Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
		Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
		Task<T> GetByIdAsync(int Id);
	}
}
