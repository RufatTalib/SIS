using SIS.Domain.Entities.Common;
using SIS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities
{
	public class Blog :  BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public bool Active { get; set; }
		public long ViewCount { get; set; }

		public string OwnerId { get; set; }
		public AppUser? Owner { get; set; }
	}
}
