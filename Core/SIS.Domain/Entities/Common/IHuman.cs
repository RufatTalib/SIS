using SIS.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities.Common
{
	public interface IHuman
	{
		public Gender Gender { get; set; }

	}
}
