using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities
{
	public class LessonEvent : Event
	{

		// Disabling for now
		// Customer can join an individual lesson
		//public string AppUserId { get; set; }
		//public AppUser? User { get; set; }

		public int GroupId { get; set; }
		public Group? Group { get; set; }


		public int ClassNumber { get; set; }

		public int SubjectId { get; set; }
		public Subject? Subject { get; set; }



	}
}