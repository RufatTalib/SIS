using SIS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities
{
	public class Subject : BaseEntity
	{
		public string Name { get; set; }

		// Hansi muellimler bu dersi kecir
		public List<AppUser>? Users { get; set; }	
		
		// hansi dersler bundandir
		public List<LessonEvent>? LessonEvents { get; set; }

	}
}
