using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.Common
{
    public class PaginatedQueryRequest<TResponse> : IRequest<TResponse> where TResponse : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
