using SIS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities
{
	public class Slider : BaseEntity
	{
        [StringLength(maximumLength: 20)]
        public string Title { get; set; }

        [StringLength(maximumLength: 70)]
        public string Caption { get; set; }
        public List<SliderImage> Images { get; set; }
	}
}
