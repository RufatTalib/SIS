using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SIS.Application.Repositories;
using SIS.Domain.Entities.Common;
using SIS.Domain.Interfaces;
using SIS.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
	{
		protected readonly SISDbContext _context;

		public DbSet<T> Table => _context.Set<T>();

		public WriteRepository(SISDbContext context)
		{
			_context = context;
		}
		
		public bool Add(T entity)
		{
			return Table.Add(entity).State == EntityState.Added;
		}
		public async Task<bool> AddAsync(T entity)
		{
			return (await Table.AddAsync(entity)).State == EntityState.Added;
		}

		public void AddRange(List<T> entities)
		{
			Table.AddRange(entities);
		}

		public async void AddRangeAsync(List<T> entities)
		{
			await Table.AddRangeAsync(entities);
		}

		public bool Update(T entity)
		{
			return Table.Update(entity).State == EntityState.Modified;
		}

		public void UpdateRange(List<T> entities)
		{
			Table.UpdateRange(entities);
		}

		public bool Delete(T entity, bool hardDelete = false)
		{
			if(hardDelete)
			{
				// hard delete entity
				return Table.Remove(entity).State == EntityState.Deleted;
			}

			entity.IsDeleted = true;
			return true;
		}

		public bool Delete(int Id, bool hardDelete = false)
		{
			return Delete(Table.FirstOrDefault(x => x.Id == Id), hardDelete);
		}

		public void Delete(List<T> entities, bool hardDelete = false)
		{
			if(hardDelete)
			{
				Table.RemoveRange(entities);
				return;
			}

			entities.ForEach(x => x.IsDeleted = true);
		}

		public async Task<int> SaveAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public int Save()
		{
			return _context.SaveChanges();
		}



	}
}
