using SIS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities
{
	public class Department : BaseEntity
	{
		public string Name { get; set; }
		public string HeadOfDepartment { get; set; }
		public DateTime StartedDate { get; set; }
		public int NumberOfStudents { get; set;}
		public List<AppUser>? Users { get; set; }

	}
}
