using SIS.Domain.Entities.Common;
using SIS.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities
{
	public class Attendance : BaseEntity
	{

		public string StudentId { get; set; }
		public AppUser? Student { get; set; }


		public int LessonEventId { get; set; }
		public LessonEvent? LessonEvent { get; set; }

		public AttendState State { get; set; }
	}
}
