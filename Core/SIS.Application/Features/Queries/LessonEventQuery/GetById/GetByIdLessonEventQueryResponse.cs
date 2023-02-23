using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.LessonEventQuery.GetById
{
	public class GetByIdLessonEventQueryResponse
	{
		public LessonEvent? LessonEvent { get; set; }
	}
}
