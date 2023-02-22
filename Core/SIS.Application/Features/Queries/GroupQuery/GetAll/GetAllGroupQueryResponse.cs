using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.GroupQuery.GetAll
{
	public class GetAllGroupQueryResponse
	{
		public PaginatedList<Group> Groups { get; set; }
	}
}
