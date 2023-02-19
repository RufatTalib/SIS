using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Infrastructure.Tools
{
	public class PaginatedList<T> : List<T>
	{
		public int ActivePage { get; private set; }
		public int TotalPage { get; private set; }

		public bool HasNext { get => ActivePage < TotalPage; }
		public bool HasPrev { get => ActivePage > 1; }

		public PaginatedList(List<T> values, int count, int page, int pageSize)
		{
			ActivePage = page;
			TotalPage = (int)Math.Ceiling( (double)count/pageSize );
			AddRange(values);
		}

		public static PaginatedList<T> Create(IQueryable<T> query, int page, int pageSize) 
		{
			return new(query.Skip((page-1)*pageSize).Take(pageSize).ToList(), query.Count(), page, pageSize);
		}
	}
}
