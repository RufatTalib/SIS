using SIS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Repositories
{
	public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
	{
		bool Add(T entity);
		Task<bool> AddAsync(T entity);
		void AddRange(List<T> entities);
		void AddRangeAsync(List<T> entities);

		bool Update(T entity);
		void UpdateRange(List<T> entities);

		bool Delete(T entity, bool hardDelete = false);
		void Delete(List<T> entities, bool hardDelete = false);

		bool Delete(int Id, bool hardDelete = false);

		Task<int> SaveAsync();
		int Save();

	}
}
