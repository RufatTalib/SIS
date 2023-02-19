using Microsoft.AspNetCore.Http;
using SIS.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.ViewModels
{
	public class AdminViewModel : RegisterVM
	{
		public Gender Gender { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime BirthDate { get; set; }
		public string? ImageUrl { get; set; }
		public IFormFile Image { get; set; }

	}
}
