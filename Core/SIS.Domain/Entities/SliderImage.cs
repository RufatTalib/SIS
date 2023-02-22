using SIS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities
{
	public class SliderImage : BaseEntity
	{
        public int SliderId { get; set; }
		public Slider? Slider { get; set; }
		public string ImageSrc { get; set; }
	}
}
