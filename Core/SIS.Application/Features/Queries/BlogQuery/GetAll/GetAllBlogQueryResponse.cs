using SIS.Application.Features.Queries.Common;
using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.BlogQuery.GetAll
{
    public class GetAllBlogQueryResponse
    {
		public PaginatedList<Blog> Blogs { get; set; }
	}
}
