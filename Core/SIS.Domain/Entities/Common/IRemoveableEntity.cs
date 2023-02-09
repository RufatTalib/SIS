using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities.Common
{
	public interface IRemoveableEntity
	{
		public bool IsDeleted { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime DeletedDate { get; set; }
	}
}
