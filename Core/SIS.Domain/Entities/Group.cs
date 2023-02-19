using SIS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities
{
	public class Group : BaseEntity
	{
		public string Name { get; set; }
		public List<AppUser>? Users { get; set; }
		public List<LessonEvent>? LessonEvents { get; set; }

	}
}
