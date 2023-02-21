using SIS.Infrastructure.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.Common
{
    public class PaginatedQueryResponse<TEntity>
    {
        public PaginatedList<TEntity> Entities { get; set; }
    }
}
