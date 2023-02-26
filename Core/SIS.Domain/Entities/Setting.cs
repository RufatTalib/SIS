using SIS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities
{
	public class Setting : BaseEntity
	{
		public string Key { get; set; }
		public string Value { get; set; }
	}
}
