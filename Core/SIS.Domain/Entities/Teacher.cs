using SIS.Domain.Entities.Common;
using SIS.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities
{
	public class Teacher : AppUser, IHuman, IRemoveableEntity
	{
		public Gender Gender { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime DeletedDate { get; set; }

		
		public DateTime QualificationDate { get; set; }
		public string Experience { get; set; }

	}
}
