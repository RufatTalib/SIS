using SIS.Domain.Entities.Common;
using SIS.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities
{
	public class Event : BaseEntity
	{
		public string Name { get; set; }
		public DateTime StartedDate { get; set; }
		public DateTime EndDate { get; set; }
		public Period Period { get; set; }

	}
}
